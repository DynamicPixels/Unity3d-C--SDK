using System;
using System.Threading.Tasks;
using models.dto;

namespace ports.utils
{
    public interface ISocketAgent
    {
        Task Connect(string endpoint, string token);
        public Task Send(Request packet);
        public event EventHandler<Request> onMessage;
    }
}