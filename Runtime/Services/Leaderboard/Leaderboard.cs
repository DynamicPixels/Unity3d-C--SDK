using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.Leaderboard.Models;
using DynamicPixels.GameService.Services.Leaderboard.Repositories;

namespace DynamicPixels.GameService.Services.Leaderboard
{
    public class LeaderboardService : ILeaderboard
    {
        private ILeaderboardRepository _repository;
        public LeaderboardService()
        {
            _repository = new LeaderboardRepository();
        }

        public async Task<List<Models.Leaderboard>> GetLeaderboards<T>(T param) where T : GetLeaderboardsParams
        {
            var result = await _repository.GetLeaderBoards(param);
            return result.List;
        }

        public async Task<List<TOutput>> GetPartiesScores<TInput, TOutput>(TInput param) where TInput : GetScoresParams where TOutput : PartyScore
        {
            var result = await _repository.GetPartiesScores<TInput, TOutput>(param);
            return result.List;
        }

        public async Task<List<TOutput>> GetUsersScores<TInput, TOutput>(TInput param) where TInput : GetScoresParams where TOutput : UserScore
        {
            var result = await _repository.GetUsersScores<TInput, TOutput>(param);

            return result.List;
        }

        public async Task<List<UserScore>> GetFriendsScores<T>(T param) where T : GetFriendsScoresParams
        {
            var result = await _repository.GetFriendsScores(param);
            return result.List;
        }

        public async Task<TOutput> GetMyScore<TInput, TOutput>(TInput param) where TInput : GetCurrentUserScoreParams where TOutput : UserScore
        {
            var result = await _repository.GetCurrentUserScore<TInput, TOutput>(param);
            return result.Row;
        }

        public async Task<TOutput> SubmitScore<TInput, TOutput>(TInput param) where TInput : SubmitScoreParams where TOutput : UserScore
        {
            var result = await _repository.SubmitScore<TInput, TOutput>(param);
            return result.Row;
        }
    }
}