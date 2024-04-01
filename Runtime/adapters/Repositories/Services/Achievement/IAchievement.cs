using System.Threading.Tasks;
using models.dto;
using models.inputs;
using models.outputs;

namespace adapters.repositories.table.services.achievement
{
    public interface IAchievementRepository
    {
        Task<RowListResponse<Model>> GetAchievements<T>(T param) where T: GetAchievementParams;
        Task<RowResponse<Unlock>> UnlockAchievement<T>(T param) where T: UnlockAchievementParams;
    }
}