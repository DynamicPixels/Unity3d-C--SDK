using System.IO;
using System.Threading.Tasks;
using DynamicPixels.GameService.Models;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Services.Achievement.Models;
using DynamicPixels.GameService.Utils.HttpClient;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Achievement.Repositories
{
    public class AchievementRepository : IAchievementRepository
    {

        public async Task<RowListResponse<Models.Achievement>> GetAchievements<T>(T input) where T : GetAchievementParams
        {
            var response = await WebRequest.Get(UrlMap.GetAchievementsUrl(input.JustUnlocked, input.Skip, input.Limit));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<RowListResponse<Models.Achievement>>(body);
            }
            else
            {
                // Deserialize the error response
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

                // Get the corresponding ErrorCode from the error message
                var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

                // Throw the DynamicPixelsException with the ErrorCode
                throw new DynamicPixelsException(errorCode, errorResponse?.Message);
            }
        }

        public async Task<RowResponse<Unlock>> UnlockAchievement<T>(T input) where T : UnlockAchievementParams
        {
            var response = await WebRequest.Post(UrlMap.UnlockAchievementUrl, input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<RowResponse<Unlock>>(body);
            }
            else
            {
                // Deserialize the error response
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

                // Get the corresponding ErrorCode from the error message
                var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

                // Throw the DynamicPixelsException with the ErrorCode
                throw new DynamicPixelsException(errorCode, errorResponse?.Message);
            }
        }
    }
}