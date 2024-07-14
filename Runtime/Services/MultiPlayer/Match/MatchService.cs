using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.MultiPlayer.Match.Models;
using DynamicPixels.GameService.Utils.HttpClient;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.MultiPlayer.Match
{
    public class MatchService : IMatchService
    {
        public Task<Match> MakeMatch(int roomId, bool lockRoom = true)
        {
            var input = new MakeMatchParams
            {
                RoomId = roomId,
                LockRoom = lockRoom
            };
            return WebRequest.Post<Match>(UrlMap.MakeMatchUrl, JsonConvert.SerializeObject(input));
        }

        public Task<Match> MakeAndStartMatch(int roomId, bool lockRoom = true)
        {
            var input = new MakeMatchParams
            {
                RoomId = roomId,
                LockRoom = lockRoom
            };
            return WebRequest.Post<Match>(UrlMap.MakeAndStartMatchUrl, JsonConvert.SerializeObject(input));
        }

        public Task<Match> LoadMatch(int matchId)
        {
            return WebRequest.Get<Match>(UrlMap.LoadMatch(matchId));
        }

        public Task<IEnumerable<MatchSummary>> GetMyMatches()
        {
            return WebRequest.Get<IEnumerable<MatchSummary>>(UrlMap.GetMyMatchesUrl);
        }
    }
}