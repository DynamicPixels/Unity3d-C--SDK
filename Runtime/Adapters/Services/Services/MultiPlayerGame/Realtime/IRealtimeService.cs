using System.Threading.Tasks;

namespace GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame.Realtime
{
    public interface IRealtimeService
    {
        Task SendMessage(int receiverId, string message);
    }
}