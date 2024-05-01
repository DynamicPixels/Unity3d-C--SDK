using System.Threading.Tasks;
using GameService.Client.Sdk.Adapters.Services.Services.Achievement;
using GameService.Client.Sdk.Models.inputs;
using GameService.Client.Sdk.Models.outputs;

namespace GameService.Client.Sdk.Adapters.Repositories.Services.Achievement
{
    public interface IAchievementRepository
    {
        Task<RowListResponse<Adapters.Services.Services.Achievement.Achievement>> GetAchievements<T>(T param) where T: GetAchievementParams;
        Task<RowResponse<Unlock>> UnlockAchievement<T>(T param) where T: UnlockAchievementParams;
    }
}