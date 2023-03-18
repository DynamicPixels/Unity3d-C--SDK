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
        Task<List<Score>> GetScores<T>(T param) where T: GetScoresParams;
        Task<List<Score>> GetFriendsScores<T>(T param) where T: GetFriendsScoresParams;
        Task<Score> GetMyScore<T>(T param) where T: GetCurrentUserScoreParams;
        Task<Score> SubmitScore<T>(T param) where T: SubmitScoreParams;
    }
}