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

        public async Task<List<PartyScore>> GetPartiesScores<T>(T param) where T : GetScoresParams
        {
            var result = await this._repository.GetPartiesScores(param);
            return result.List;
        }
        
        public async Task<List<UserScore>> GetUsersScores<T>(T param) where T : GetScoresParams
        {
            var result = await this._repository.GetUsersScores(param);
            return result.List;
        }

        public async Task<List<UserScore>> GetFriendsScores<T>(T param) where T : GetFriendsScoresParams
        {
            var result = await this._repository.GetFriendsScores(param);
            return result.List;
        }

        public async Task<UserScore> GetMyScore<T>(T param) where T : GetCurrentUserScoreParams
        {
            var result = await this._repository.GetCurrentUserScore(param);
            return result.Row;
        }

        public async Task<BaseScore> SubmitScore<T>(T param) where T : SubmitScoreParams
        {
            var result = await this._repository.SubmitScore(param);
            return result.Row;
        }
    }
}