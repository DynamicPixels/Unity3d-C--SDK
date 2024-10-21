using System.Threading.Tasks;
using DynamicPixels.GameService.Models;
using DynamicPixels.GameService.ModuleFramework.Messaging;

namespace DynamicPixels.GameService.Services.MultiPlayer.Realtime
{
    public class RealtimeService : IRealtimeService
    {
        private readonly IWebSocketService _socketAgent;

        public RealtimeService(IWebSocketService socketAgent)
        {
            _socketAgent = socketAgent;
        }

        public Task SendMessage(int receiverId, string message)
        {
            var packet = new Request()
            {
                Method = "room:broadcast",
                Payload = message
            };

            return _socketAgent.SendAsync(packet);
        }
    }
}