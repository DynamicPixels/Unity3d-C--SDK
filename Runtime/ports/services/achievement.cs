using System.Collections.Generic;
using System.Threading.Tasks;
using models.dto;
using models.inputs;
using models.outputs;

namespace ports.services
{
    public interface IAchievement
    {
        Task<List<RichAchievement>> GetAchievements<T>(T param) where T: GetAchievementParams;
        Task<Unlock> UnlockAchievement<T>(T param) where T: UnlockAchievementParams;
    }
}