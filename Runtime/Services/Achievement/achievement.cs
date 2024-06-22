using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.Achievement.Models;
using DynamicPixels.GameService.Services.Achievement.Repositories;

namespace DynamicPixels.GameService.Services.Achievement
{
    public class AchievementService : IAchievement
    {

        private IAchievementRepository _repository;

        public AchievementService()
        {
            _repository = new AchievementRepository();
        }

        public async Task<List<Models.Achievement>> GetAchievements<T>(T param) where T : GetAchievementParams
        {
            var result = await _repository.GetAchievements(param);
            return result.List;
        }

        public async Task<Unlock> UnlockAchievement<T>(T param) where T : UnlockAchievementParams
        {
            var result = await _repository.UnlockAchievement(param);
            return result.Row;
        }
    }
}