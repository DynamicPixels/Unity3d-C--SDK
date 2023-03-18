using System.Collections.Generic;
using System.Threading.Tasks;
using adapters.repositories.table.services.achievement;
using models.inputs;
using models.outputs;
using adapters.repositories.table.services.achievement;
using models.dto;
using ports;
using ports.services;
using ports.utils;

namespace adapters.services.table.services
{
    public class AchievementService: IAchievement
    {

        private IAchievementRepository _repository;
        
        public AchievementService()
        {
            this._repository = new AchievementRepository();
        }

        public async Task<List<Achievement>> GetAchievements<T>(T param) where T : GetAchievementParams
        {
            var result = await this._repository.GetAchievements(param);
            return result.List;
        }

        public async Task<List<Unlock>> GetUserAchievements<T>(T param) where T : GetUserAchievementsParams
        {
            var result = await this._repository.GetUserAchievements(param);
            return result.List;
        }

        public async Task<Unlock> UnlockAchievement<T>(T param) where T : UnlockAchievementParams
        {
            var result = await this._repository.UnlockAchievement(param);
            return result.Row;
        }
    }
}