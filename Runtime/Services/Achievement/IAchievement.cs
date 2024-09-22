using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.Achievement.Models;

namespace DynamicPixels.GameService.Services.Achievement
{
    public interface IAchievement
    {
        /// <summary>
        /// Retrieves a list of achievements for the current user based on the provided parameters.
        /// </summary>
        /// <typeparam name="T">The type of the input parameter, which must derive from <see cref="GetAchievementParams"/>.</typeparam>
        /// <param name="param">An instance of <typeparamref name="T"/> containing the parameters for retrieving achievements.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Models.Achievement"/> objects representing the user's achievements.</returns>
        Task<List<Models.Achievement>> GetAchievements<T>(T param) where T : GetAchievementParams;

        /// <summary>
        /// Unlocks an achievement for the current user based on the provided parameters.
        /// </summary>
        /// <typeparam name="T">The type of the input parameter, which must derive from <see cref="UnlockAchievementParams"/>.</typeparam>
        /// <param name="param">An instance of <typeparamref name="T"/> containing the parameters for unlocking the achievement.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="Unlock"/> object representing the unlocked achievement.</returns>
        Task<Unlock> UnlockAchievement<T>(T param) where T : UnlockAchievementParams;

    }
}