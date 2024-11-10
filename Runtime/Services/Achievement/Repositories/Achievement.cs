using System.Threading.Tasks;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Services.Achievement.Models;
using DynamicPixels.GameService.Utils.HttpClient;

namespace DynamicPixels.GameService.Services.Achievement.Repositories
{
    public class AchievementRepository : IAchievementRepository
    {

        public Task<RowListResponse<Models.Achievement>> GetAchievements<T>(T input) where T : GetAchievementParams
        {
            return WebRequest.Get<RowListResponse<Models.Achievement>>(UrlMap.GetAchievementsUrl(input.JustUnlocked, input.Skip, input.Limit));
        }

        public Task<RowResponse<Unlock>> UnlockAchievement<T>(T input) where T : UnlockAchievementParams
        {
            return WebRequest.Post<RowResponse<Unlock>>(UrlMap.UnlockAchievementUrl, input.ToString());
        }
    }
}