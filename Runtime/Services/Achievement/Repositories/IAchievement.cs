using System.Threading.Tasks;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Services.Achievement.Models;

namespace DynamicPixels.GameService.Services.Achievement.Repositories
{
    public interface IAchievementRepository
    {
        Task<RowListResponse<Models.Achievement>> GetAchievements<T>(T param) where T : GetAchievementParams;
        Task<RowResponse<Unlock>> UnlockAchievement<T>(T param) where T : UnlockAchievementParams;
    }
}