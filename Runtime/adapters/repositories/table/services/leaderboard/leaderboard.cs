
using System.IO;
using System.Threading.Tasks;
using adapters.utils.httpClient;
using models;
using models.dto;
using models.inputs;
using models.outputs;
using Newtonsoft.Json;
using ports;
using ports.utils;
using UnityEngine;

namespace adapters.repositories.table.services.leaderboard
{
    public class LeaderboardRepository : ILeaderboardRepository
    {

        public LeaderboardRepository()
        {
        }

        public async Task<RowListResponse<Leaderboard>> GetLeaderBoards<T>(T input) where T : GetLeaderboardsParams
        {
            var response = await WebRequest.Get(UrlMap.GetLeaderboardsUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<Leaderboard>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);

        }

        public async Task<RowListResponse<Score>> GetScores<T>(T input) where T : GetScoresParams
        {
            var response = await WebRequest.Get(UrlMap.GetScoresUrl(input.LeaderboardId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<Score>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowResponse<Score>> GetCurrentUserScore<T>(T input) where T : GetCurrentUserScoreParams
        {
            var response = await WebRequest.Get(UrlMap.GetCurrentUserScoreUrl(input.LeaderboardId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<Score>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowListResponse<Score>> GetFriendsScores<T>(T input) where T : GetFriendsScoresParams
        {
            var response = await WebRequest.Get(UrlMap.GetMyFriendsScoreUrl(input.LeaderboardId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<Score>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowResponse<Score>> SubmitScore<T>(T input) where T : SubmitScoreParams
        {
            var response = await WebRequest.Post(UrlMap.SubmitScoreUrl(input.LeaderboardId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<Score>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }
    }
}