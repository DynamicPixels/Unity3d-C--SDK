using System.Threading.Tasks;
using GameService.Client.Sdk.Adapters.Repositories.Messaging;
using GameService.Client.Sdk.Adapters.Utils.WebsocketClient;

namespace GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame.Realtime
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