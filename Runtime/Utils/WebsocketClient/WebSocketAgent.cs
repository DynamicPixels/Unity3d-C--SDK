using System;
using System.Threading.Tasks;
using GameService.Client.Sdk.Models;
using GameService.Client.Sdk.Repositories.Messaging;
using GameService.Client.Sdk.Utils.Logger;
using GameService.Client.Sdk.Utils.WebsocketClient;
using Newtonsoft.Json;
using UnityEngine;
using WebSocketSharp;

namespace GameService.Client.Sdk.Adapters.Utils.WebsocketClient
{
    public class WebSocketAgent : ISocketAgent
    {
        private static WebSocket _ws;
        private bool _isAvailable;
        private string _endpoint;
        private string _token;
        private System.Timers.Timer _pingInterval;
        private long _lastPingSentTime;
        private long _ping;
        public event EventHandler<Request> OnMessageReceived;
        public event EventHandler OnDisconnect;

        public bool IsConnected()
        {
            return _ws != null && _isAvailable;
        }

        public Task Connect(string endpoint, string token)
        {
            LogHelper.LogNormal<string>(DebugLocation.Connection, "Connect", "Connecting to " + endpoint);

            _endpoint = endpoint;
            _token = token;

            _ws = new WebSocket(endpoint + $"?token={token}");
            _ws.OnOpen += OnOpen;
            _ws.OnClose += OnClose;
            _ws.OnError += OnError;
            _ws.OnMessage += OnMessage;

            _ws.ConnectAsync();

            return Task.CompletedTask;
        }

        public void Disconnect()
        {
            _ws.Close();
        }

        public long GetPing()
        {
            return _ping;
        }

        public Task Send(Request request)
        {
            if (!_isAvailable)
                LogHelper.LogException<DynamicPixelsException>(new DynamicPixelsException(ErrorCode.ConnectionNotReady, "connection not ready"), DebugLocation.Connection, "Send");
            try
            {
                _ws.SendAsync(request.ToString(), null);
                _lastPingSentTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            }
            catch (Exception e)
            {
                if (
                    e is OperationCanceledException ||
                    e is ObjectDisposedException ||
                    e is ArgumentOutOfRangeException
                ) return Task.CompletedTask;

                _isAvailable = false;
            }

            return Task.CompletedTask;
        }

        private async void OnSendPing(object sender, System.Timers.ElapsedEventArgs args)
        {
            await Send(new Request
            {
                Method = "ping",
            });
        }

        private void OnMessage(object sender, MessageEventArgs message)
        {
            if (!message.IsText) return;

            var response = JsonConvert.DeserializeObject<Request>(message.Data);
            if (response.Method == "ping")
            {
                _ping = _lastPingSentTime - DateTimeOffset.Now.ToUnixTimeMilliseconds();
                Debug.Log("pong!");
                return;
            }

            if (OnMessageReceived != null)
                OnMessageReceived(this, response);
        }

        private void OnError(object sender, ErrorEventArgs error)
        {
            if (error.Exception != null)
            {
                LogHelper.LogException<Exception>(error.Exception, DebugLocation.Connection, "onError");
            }
            else
            {
                // Use a generic error code for errors without a specific exception
                var exception = new DynamicPixelsException(ErrorCode.UnknownError, error.Message);
                LogHelper.LogException<DynamicPixelsException>(exception, DebugLocation.Connection, "onError");
            }
        }

        private void OnClose(object sender, CloseEventArgs close)
        {
            LogHelper.LogNormal<string>(DebugLocation.Connection, "Connect", "Disconnected from " + close.Reason);
            _pingInterval.Dispose();
            if (!_isAvailable || close.WasClean) return;
            _isAvailable = false;
            if (OnDisconnect != null)
                OnDisconnect(this, null);
        }

        private void OnOpen(object sender, EventArgs e)
        {
            LogHelper.LogNormal<string>(DebugLocation.Connection, "Connect", "Connected to " + _endpoint);
            _isAvailable = true;

            _pingInterval = new System.Timers.Timer();
            _pingInterval.Interval = 10 * 1000;
            _pingInterval.AutoReset = true;
            _pingInterval.Elapsed += OnSendPing;
            _pingInterval.Start();
        }

    }
}