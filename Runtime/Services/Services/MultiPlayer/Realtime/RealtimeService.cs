using System.Threading.Tasks;
using GameService.Client.Sdk.Repositories.Messaging;
using GameService.Client.Sdk.Utils.WebsocketClient;

namespace GameService.Client.Sdk.Services.Services.MultiPlayer.Realtime
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