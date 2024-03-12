using System.Threading.Tasks;
using models.dto;
using models.inputs;
using models.outputs;

namespace adapters.repositories.table.services.leaderboard
{
    public interface ILeaderboardRepository
    {
        Task<RowListResponse<Leaderboard>> GetLeaderBoards<T>(T param) where T : GetLeaderboardsParams;
        Task<RowListResponse<TOutput>> GetUsersScores<TInput, TOutput>(TInput param)
            where TInput : GetScoresParams
            where TOutput : UserScore;
        Task<RowListResponse<TOutput>> GetPartiesScores<TInput, TOutput>(TInput param)
            where TInput : GetScoresParams
            where TOutput : PartyScore;
        Task<RowResponse<TOutput>> GetCurrentUserScore<TInput, TOutput>(TInput param)
            where TInput : GetCurrentUserScoreParams
            where TOutput : UserScore;
        Task<RowListResponse<UserScore>> GetFriendsScores<T>(T param) where T : GetFriendsScoresParams;
        Task<RowResponse<TOutput>> SubmitScore<TInput, TOutput>(TInput param)
            where TInput : SubmitScoreParams
            where TOutput : UserScore;

    }

}