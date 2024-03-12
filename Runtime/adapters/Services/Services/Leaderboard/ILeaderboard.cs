using System.Collections.Generic;
using System.Threading.Tasks;
using models.dto;
using models.inputs;
using models.outputs;

namespace adapters.services.table.services
{
    public interface ILeaderboard
    {
        Task<List<Leaderboard>> GetLeaderboards<T>(T param) where T: GetLeaderboardsParams;
        Task<List<TOutput>> GetUsersScores<TInput, TOutput>(TInput param) where TInput : GetScoresParams where TOutput : UserScore;
        Task<List<TOutput>> GetPartiesScores<TInput, TOutput>(TInput param) where TInput : GetScoresParams where TOutput : PartyScore;
        Task<List<UserScore>> GetFriendsScores<T>(T param) where T: GetFriendsScoresParams;
        Task<TOutput> GetMyScore<TInput, TOutput>(TInput param) where TInput : GetCurrentUserScoreParams where TOutput : UserScore;
        Task<TOutput> SubmitScore<TInput, TOutput>(TInput param) where TInput : SubmitScoreParams where TOutput : UserScore;
    }
}