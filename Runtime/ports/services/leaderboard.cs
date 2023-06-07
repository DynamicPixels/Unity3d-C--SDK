using System.Collections.Generic;
using System.Threading.Tasks;
using models.dto;
using models.inputs;
using models.outputs;

namespace ports.services
{
    public interface ILeaderboard
    {
        Task<List<Leaderboard>> GetLeaderboards<T>(T param) where T: GetLeaderboardsParams;
        Task<List<UserScore>> GetUsersScores<T>(T param) where T: GetScoresParams;
        Task<List<PartyScore>> GetPartiesScores<T>(T param) where T: GetScoresParams;
        Task<List<UserScore>> GetFriendsScores<T>(T param) where T: GetFriendsScoresParams;
        Task<UserScore> GetMyScore<T>(T param) where T: GetCurrentUserScoreParams;
        Task<BaseScore> SubmitScore<T>(T param) where T: SubmitScoreParams;
    }
}