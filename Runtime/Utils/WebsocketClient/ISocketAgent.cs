using System;
using System.Threading.Tasks;
using GameService.Client.Sdk.Repositories.Messaging;

namespace GameService.Client.Sdk.Utils.WebsocketClient
{
    public interface ISocketAgent
    {
        Task Connect(string endpoint, string token);
        void Disconnect();
        long GetPing();
        public Task Send(Request packet);
        public event EventHandler<Request> OnMessageReceived;
        public event EventHandler OnDisconnect;
    }
}