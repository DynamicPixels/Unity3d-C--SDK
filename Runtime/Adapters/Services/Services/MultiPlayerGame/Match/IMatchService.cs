using System.Threading.Tasks;

namespace GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame.Match
{
    public interface IMatchService
    {
        Task<Match> MakeMatch(int roomId);
        Task<Match> MakeAndStartMatch(int roomId);
        Task<Match> GetMatchById(int matchId);
    }
}