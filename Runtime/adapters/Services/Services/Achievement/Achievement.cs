using System.Collections.Generic;
using System.Threading.Tasks;
using GameService.Client.Sdk.Adapters.Repositories.Services.Achievement;
using GameService.Client.Sdk.Models.inputs;

namespace GameService.Client.Sdk.Adapters.Services.Services.Achievement
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

        public async Task<Unlock> UnlockAchievement<T>(T param) where T : UnlockAchievementParams
        {
            var result = await this._repository.UnlockAchievement(param);
            return result.Row;
        }
    }
}