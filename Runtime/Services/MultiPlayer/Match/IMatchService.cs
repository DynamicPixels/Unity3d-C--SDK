using System.Threading.Tasks;

namespace DynamicPixels.GameService.Services.MultiPlayer.Match
{
    public interface IMatchService
    {
        Task<Match> MakeMatch(int roomId, bool lockRoom = true);
        Task<Match> MakeAndStartMatch(int roomId, bool lockRoom = true);
        Task<Match> GetMatchById(int matchId);
    }
}