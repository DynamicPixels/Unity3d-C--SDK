using System;
using System.Threading.Tasks;
using DynamicPixels.GameService.Models;

namespace DynamicPixels.GameService.Utils.WebsocketClient
{
    public interface IWebSocketService
    {
        public event EventHandler<Request> OnMessageReceived;
        public event EventHandler OnDisconnect;
        WebSocketStatus ConnectionStatus { get; }
        IWebSocketService Config(WebSocketConfiguration config);
        Task ConnectAsync(string token);
        bool IsConnectionReady();
        Task DisconnectAsync();
        Task SendAsync(Request message);
        Task SendAsync(string message);
        void Dispose();
    }
}
