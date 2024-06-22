using System.Threading.Tasks;
using DynamicPixels.GameService.Models;
using DynamicPixels.GameService.Utils.WebsocketClient;

namespace DynamicPixels.GameService.Services.MultiPlayer.Realtime
{
    public class RealtimeService : IRealtimeService
    {
        private readonly ISocketAgent _socketAgent;

        public RealtimeService(ISocketAgent socketAgent)
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

            return _socketAgent.Send(packet);
        }
    }
}