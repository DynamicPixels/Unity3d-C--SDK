using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DynamicPixels.GameService.Models;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Utils.WebsocketClient
{
    internal sealed class WebSocketService : IWebSocketService
    {
        private static ClientWebSocket _clientWebSocket = new();
        private static WebSocketConfiguration _configuration = default!;
        private static string _token;
        private Timer _pingTimer;
        public event EventHandler<Request> OnMessageReceived;
        public event EventHandler OnDisconnect;

        public WebSocketStatus ConnectionStatus { get; private set; } = WebSocketStatus.Disconnected;


        public IWebSocketService Config(WebSocketConfiguration config)
        {
            _configuration = config;
            _pingTimer = new Timer(SendPing, null, Timeout.Infinite, Timeout.Infinite);

            return this;
        }

        public Task ConnectAsync(string token)
        {
            _token = token;
            return ConnectWithRetryAsync();
        }

        public bool IsConnectionReady()
        {
            return ConnectionStatus == WebSocketStatus.Connected && _clientWebSocket.State == WebSocketState.Open;
        }

        public async Task DisconnectAsync()
        {
            _pingTimer.Change(Timeout.Infinite, Timeout.Infinite); // Stop the timer

            switch (_clientWebSocket.State)
            {
                case WebSocketState.Open:
                    await _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing",
                        CancellationToken.None);
                    Console.WriteLine("Websocket has been closed.\n");
                    break;
                case WebSocketState.Aborted:
                    Console.WriteLine("Websocket is Aborted.\n");
                    _clientWebSocket.Dispose();
                    break;
                default:
                    Console.WriteLine("Connection is closed or not ready.\n");
                    break;
            }

            ConnectionStatus = WebSocketStatus.Disconnected;
        }

        public async Task SendAsync(Request request)
        {
            var message = request.ToString();
            if (!IsConnectionReady())
                throw new Exception("Sending failed; Connection is not ready.");

            try
            {
                await _clientWebSocket.SendAsync(
                    Encoding.UTF8.GetBytes(message),
                    WebSocketMessageType.Text,
                    true,
                    CancellationToken.None
                );

                Console.WriteLine($"Message Sent: {message} \n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}\n");
            }
        }
        
        public async Task SendAsync(string message)
        {
            if (!IsConnectionReady())
                throw new Exception("Sending failed; Connection is not ready.");

            try
            {
                await _clientWebSocket.SendAsync(
                    Encoding.UTF8.GetBytes(message),
                    WebSocketMessageType.Text,
                    true,
                    CancellationToken.None
                );

                Console.WriteLine($"Message Sent: {message} \n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}\n");
            }
        }

        public void Dispose()
        {
            OnMessageReceived = null;
            OnDisconnect = null;
        }

        // private methods
        private async Task ConnectWithRetryAsync()
        {
            if (ConnectionStatus is not WebSocketStatus.Disconnected)
                return;

            ConnectionStatus = WebSocketStatus.Connecting;

            for (var attempt = 0;
                 attempt < _configuration.MaxReconnectAttempts && _clientWebSocket.State != WebSocketState.Open;
                 attempt++)
                try
                {
                    Console.WriteLine($"Connecting to {_configuration.WebSocketUrl}\n");
                    _clientWebSocket
                        .ConnectAsync(new Uri(_configuration.WebSocketUrl + $"?token={_token}"), CancellationToken.None)
                        .GetAwaiter()
                        .GetResult();

                    ConnectionStatus = WebSocketStatus.Connected;
                    Console.WriteLine($"Connected to {_configuration.WebSocketUrl}\n");

                    _pingTimer.Change(TimeSpan.FromSeconds(_configuration.PingInterval),
                        TimeSpan.FromSeconds(_configuration.PingInterval)); // Start the timer
                    ReceiveMessagesAsync();
                }
                catch (Exception ex)
                {
                    if (ex is ObjectDisposedException)
                        _clientWebSocket = new ClientWebSocket();

                    Console.WriteLine($"Connection attempt {attempt + 1} failed: {ex.Message}\n");

                    if (attempt == _configuration.MaxReconnectAttempts - 1)
                        throw;

                    await Task.Delay(TimeSpan.FromSeconds(_configuration.ReconnectDelay));
                }
        }

        private async Task ReceiveMessagesAsync()
        {
            var buffer = new ArraySegment<byte>(new byte[1024 * 4]);
            while (_clientWebSocket.State == WebSocketState.Open)
                try
                {
                    using var ms = new MemoryStream();
                    WebSocketReceiveResult result;

                    do
                    {
                        result = await _clientWebSocket.ReceiveAsync(buffer, CancellationToken.None);

                        if (buffer.Array != null)
                            ms.Write(buffer.Array, buffer.Offset, result.Count);
                    } while (!result.EndOfMessage);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        Console.WriteLine("Close message received.\n");
                        await DisconnectAsync();
                        break;
                    }

                    ms.Seek(0, SeekOrigin.Begin);
                    using var reader = new StreamReader(ms, Encoding.UTF8);
                    var body = await reader.ReadToEndAsync();

                    if (body != "{\"4\":\"ping\",\"5\":\"pong\"}\n")
                        Console.WriteLine($"Message Received: {body.Trim()}\n");

                    Request? msg = null;

                    try
                    {
                        msg = JsonConvert.DeserializeObject<Request>(body.Trim());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    if (msg == null)
                        continue;

                    OnMessageReceived?.Invoke(this, msg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Cant read message: {ex}\n");
                    await DisconnectAsync();
                    await ConnectWithRetryAsync();
                }
        }

        private async void SendPing(object state)
        {
            await SendAsync("{\"4\":\"ping\",\"5\":\"ping\"}");
        }

        private object? CreateInstance(Type dataType)
        {
            return dataType switch
            {
                { } when dataType == typeof(string) => string.Empty,
                { } when dataType == typeof(int) => 0,
                null => null,
                _ => Activator.CreateInstance(dataType)
            };
        }
    }
}