using System.Collections.Generic;
using System.Threading.Tasks;
using GameService.Client.Sdk.Models.inputs;

namespace GameService.Client.Sdk.Adapters.Services.Services.Achievement
{
    public interface IAchievement
    {
        Task<List<Achievement>> GetAchievements<T>(T param) where T: GetAchievementParams;
        Task<Unlock> UnlockAchievement<T>(T param) where T: UnlockAchievementParams;
    }
}