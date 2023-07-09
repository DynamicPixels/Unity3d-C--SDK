
using System;
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

        public async Task<RowListResponse<PartyScore>> GetPartiesScores<T>(T input) where T : GetScoresParams
        {
            var response = await WebRequest.Get(UrlMap.GetPartiesScoresUrl(input.LeaderboardId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<PartyScore>>(body);

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body)?.Message);
        }

        public async Task<RowListResponse<UserScore>> GetUsersScores<T>(T input) where T : GetScoresParams
        {
            var response = await WebRequest.Get(UrlMap.GetUsersScoresUrl(input.LeaderboardId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<UserScore>>(body);

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body)?.Message);
        }

        public async Task<RowResponse<UserScore>> GetCurrentUserScore<T>(T input) where T : GetCurrentUserScoreParams
        {
            var response = await WebRequest.Get(UrlMap.GetCurrentUserScoreUrl(input.LeaderboardId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<UserScore>>(body);

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body)?.Message);
        }

        public async Task<RowListResponse<UserScore>> GetFriendsScores<T>(T input) where T : GetFriendsScoresParams
        {
            var response = await WebRequest.Get(UrlMap.GetMyFriendsScoreUrl(input.LeaderboardId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<UserScore>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowResponse<BaseScore>> SubmitScore<T>(T input) where T : SubmitScoreParams
        {
            var response = await WebRequest.Post(UrlMap.SubmitScoreUrl(input.LeaderboardId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<BaseScore>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }
    }
}