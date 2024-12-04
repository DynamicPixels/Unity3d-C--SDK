using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.MultiPlayer.Match.Models;

namespace DynamicPixels.GameService.Services.MultiPlayer.Match
{
    public interface IMatchService
    {
        Task<Match> MakeMatch(int roomId, bool lockRoom = true);
        Task<Match> MakeAndStartMatch(int roomId, bool lockRoom = true);
        Task<Match> LoadMatch(int matchId);
        Task<IEnumerable<MatchSummary>> GetMyMatches();
    }
}