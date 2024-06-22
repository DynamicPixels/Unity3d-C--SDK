using System.Threading.Tasks;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Services.Leaderboard.Models;

namespace DynamicPixels.GameService.Services.Leaderboard.Repositories
{
    public interface ILeaderboardRepository
    {
        Task<RowListResponse<Models.Leaderboard>> GetLeaderBoards<T>(T param) where T : GetLeaderboardsParams;
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