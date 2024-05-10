using System.Threading.Tasks;

namespace GameService.Client.Sdk.Services.Services.MultiPlayer.Match
{
    public interface IMatchService
    {
        Task<Match> MakeMatch(int roomId);
        Task<Match> MakeAndStartMatch(int roomId);
        Task<Match> GetMatchById(int matchId);
    }
}