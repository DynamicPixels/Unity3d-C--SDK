using System;
using System.Threading.Tasks;
using GameService.Client.Sdk.Adapters.Repositories.Messaging;

namespace GameService.Client.Sdk.Adapters.Utils.WebsocketClient
{
    public interface ISocketAgent
    {
        Task Connect(string endpoint, string token);
        void Disconnect();
        long GetPing();
        public Task Send(Request packet);
        public event EventHandler<Request> OnMessageReceived;
    }
}