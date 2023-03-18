using System.IO;
using System.Threading.Tasks;
using adapters.utils.httpClient;
using models;
using models.dto;
using models.inputs;
using models.outputs;
using Newtonsoft.Json;
using ports;

namespace adapters.repositories.table.services.achievement
{
    public class AchievementRepository: IAchievementRepository
    {

        public AchievementRepository()
        {
        }

        public async Task<RowListResponse<Achievement>> GetAchievements<T>(T input) where T : GetAchievementParams
        {
            var response = await WebRequest.Get(UrlMap.GetAchievementsUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<Achievement>>(await reader.ReadToEndAsync());

            throw new BlueGException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowListResponse<Unlock>> GetUserAchievements<T>(T input) where T : GetUserAchievementsParams
        {
            var response = await WebRequest.Get(UrlMap.GetUserAchievementsUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<Unlock>>(await reader.ReadToEndAsync());

            throw new BlueGException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowResponse<Unlock>> UnlockAchievement<T>(T input) where T : UnlockAchievementParams
        {
            var response = await WebRequest.Post(UrlMap.UnlockAchievementUrl, input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<Unlock>>(await reader.ReadToEndAsync());

            throw new BlueGException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }
    }
}