using System.Threading.Tasks;

namespace DynamicPixels.GameService.Services.MultiPlayer.Realtime
{
    public interface IRealtimeService
    {
        Task SendMessage(int receiverId, string message);
    }
}