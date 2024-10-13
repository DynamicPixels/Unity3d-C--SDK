using System;
using System.Threading.Tasks;
using DynamicPixels.GameService.Models;

namespace DynamicPixels.GameService.Utils.WebsocketClient
{
    public interface ISocketAgent
    {
        void SetReconnectValues(float reconnectDelay, int maxAttempts);
        Task Connect(string endpoint, string token);
        void Disconnect();
        long GetPing();
        public Task Send(Request packet);
        public event EventHandler<Request> OnMessageReceived;
        public event EventHandler OnDisconnect;
    }
}