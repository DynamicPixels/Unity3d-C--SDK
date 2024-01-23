using System.Collections.Generic;
using System.Threading.Tasks;
using adapters.repositories.table.services.achievement;
using models.inputs;
using models.dto;
using ports;
using ports.services;

namespace adapters.services.table.services
{
    public class AchievementService: IAchievement
    {

        private IAchievementRepository _repository;
        
        public AchievementService()
        {
            this._repository = new AchievementRepository();
        }

        public async Task<List<RichAchievement>> GetAchievements<T>(T param) where T : GetAchievementParams
        {
            var result = await this._repository.GetAchievements(param);
            return result.List;
        }

        public async Task<Unlock> UnlockAchievement<T>(T param) where T : UnlockAchievementParams
        {
            var result = await this._repository.UnlockAchievement(param);
            return result.Row;
        }
    }
}