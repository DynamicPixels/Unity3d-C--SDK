using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.MultiPlayer.Match.Models;
using DynamicPixels.GameService.Utils.HttpClient;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.MultiPlayer.Match
{
    /// <summary>
    /// Provides services for managing multiplayer matches, including creating, starting, and loading matches.
    /// </summary>
    public class MatchService : IMatchService
    {
        /// <summary>
        /// Creates a new match in the specified room.
        /// </summary>
        /// <param name="roomId">The ID of the room where the match will be created.</param>
        /// <param name="lockRoom">
        /// Specifies whether to lock the room after creating the match.
        /// Default is <c>true</c>.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, with a result containing the created match details.
        /// </returns>
        public Task<Match> MakeMatch(int roomId, bool lockRoom = true)
        {
            var input = new MakeMatchParams
            {
                RoomId = roomId,
                LockRoom = lockRoom
            };
            return WebRequest.Post<Match>(UrlMap.MakeMatchUrl, JsonConvert.SerializeObject(input));
        }

        /// <summary>
        /// Creates and starts a new match in the specified room.
        /// </summary>
        /// <param name="roomId">The ID of the room where the match will be created and started.</param>
        /// <param name="lockRoom">
        /// Specifies whether to lock the room after creating the match.
        /// Default is <c>true</c>.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation, with a result containing the started match details.
        /// </returns>
        public Task<Match> MakeAndStartMatch(int roomId, bool lockRoom = true)
        {
            var input = new MakeMatchParams
            {
                RoomId = roomId,
                LockRoom = lockRoom
            };
            return WebRequest.Post<Match>(UrlMap.MakeAndStartMatchUrl, JsonConvert.SerializeObject(input));
        }

        /// <summary>
        /// Loads the details of a specific match by its ID.
        /// </summary>
        /// <param name="matchId">The ID of the match to load.</param>
        /// <returns>
        /// A task representing the asynchronous operation, with a result containing the match details.
        /// </returns>
        public Task<Match> LoadMatch(int matchId)
        {
            return WebRequest.Get<Match>(UrlMap.LoadMatch(matchId));
        }

        /// <summary>
        /// Retrieves a list of matches associated with the current user.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation, with a result containing a list of match summaries.
        /// </returns>
        public Task<IEnumerable<MatchSummary>> GetMyMatches()
        {
            return WebRequest.Get<IEnumerable<MatchSummary>>(UrlMap.GetMyMatchesUrl);
        }
    }
}
