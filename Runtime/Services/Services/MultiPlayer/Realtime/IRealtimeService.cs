using System.Threading.Tasks;

namespace GameService.Client.Sdk.Services.Services.MultiPlayer.Realtime
{
    public interface IRealtimeService
    {
        Task SendMessage(int receiverId, string message);
    }
}