using System.Threading.Tasks;
using GameService.Client.Sdk.Models.inputs;
using GameService.Client.Sdk.Models.outputs;
using GameService.Client.Sdk.Services.Services.Achievement;

namespace GameService.Client.Sdk.Repositories.Services.Achievement
{
    public interface IAchievementRepository
    {
        Task<RowListResponse<Sdk.Services.Services.Achievement.Achievement>> GetAchievements<T>(T param) where T : GetAchievementParams;
        Task<RowResponse<Unlock>> UnlockAchievement<T>(T param) where T : UnlockAchievementParams;
    }
}