using System;
using System.Threading.Tasks;
using models.dto;

namespace adapters.utils.WebsocketClient
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