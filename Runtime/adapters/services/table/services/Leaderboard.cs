using System.Collections.Generic;
using System.Threading.Tasks;
using adapters.repositories.table.services.leaderboard;
using models.dto;
using models.inputs;
using models.outputs;
using ports;
using ports.services;
using ports.utils;

namespace adapters.services.table.services
{
    public class LeaderboardService: ILeaderboard
    {
        private ILeaderboardRepository _repository;
        public LeaderboardService()
        {
            this._repository = new LeaderboardRepository();
        }

        public async Task<List<Leaderboard>> GetLeaderboards<T>(T param) where T : GetLeaderboardsParams
        {
            var result = await this._repository.GetLeaderBoards(param);
            return result.List;
        }

        public async Task<List<TOutput>> GetPartiesScores<TInput, TOutput>(TInput param) where TInput : GetScoresParams where TOutput : PartyScore
        {
            var result = await this._repository.GetPartiesScores<TInput, TOutput>(param);
            return result.List;
        }

        public async Task<List<TOutput>> GetUsersScores<TInput, TOutput>(TInput param) where TInput : GetScoresParams where TOutput : UserScore
        {
            var result = await this._repository.GetUsersScores<TInput, TOutput>(param);

            return result.List;
        }

        public async Task<List<UserScore>> GetFriendsScores<T>(T param) where T : GetFriendsScoresParams
        {
            var result = await this._repository.GetFriendsScores(param);
            return result.List;
        }

        public async Task<TOutput> GetMyScore<TInput, TOutput>(TInput param) where TInput : GetCurrentUserScoreParams where TOutput : UserScore
        {
            var result = await this._repository.GetCurrentUserScore<TInput, TOutput>(param);
            return result.Row;
        }

        public async Task<TOutput> SubmitScore<TInput, TOutput>(TInput param) where TInput : SubmitScoreParams where TOutput : UserScore
        {
            var result = await this._repository.SubmitScore<TInput, TOutput>(param);
            return result.Row;
        }
    }
}