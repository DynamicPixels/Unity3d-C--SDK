using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.Achievement.Models;

namespace DynamicPixels.GameService.Services.Achievement
{
    public interface IAchievement
    {
        
        Task<List<Models.Achievement>> GetAchievements<T>(T param) where T : GetAchievementParams;
        Task<Unlock> UnlockAchievement<T>(T param) where T : UnlockAchievementParams;

    }
}