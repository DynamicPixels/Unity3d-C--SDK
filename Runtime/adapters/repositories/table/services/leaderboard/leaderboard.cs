
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

        public async Task<RowListResponse<Leaderboard>> GetLeaderBoards<T>(T input) where T : GetLeaderboardsParams
        {
            var response = await WebRequest.Get(UrlMap.GetLeaderboardsUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<Leaderboard>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);

        }

        public async Task<RowListResponse<TOutput>> GetPartiesScores<TInput, TOutput>(TInput input)
           where TInput : GetScoresParams
           where TOutput : UserScore
        {
            var response = await WebRequest.Post(UrlMap.GetPartiesScoresUrl(input.Leaderboardid, input.skip, input.limit), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<TOutput>>(body);

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body)?.Message);
        }

        public async Task<RowListResponse<TOutput>> GetUsersScores<TInput, TOutput>(TInput input)
            where TInput : GetScoresParams
            where TOutput : UserScore
        {
            Debug.Log(input.ToString());
            var response = await WebRequest.Post(UrlMap.GetUsersScoresUrl(input.Leaderboardid, input.skip, input.limit), input.ToString());
            Debug.Log("reponse: "+ UrlMap.GetUsersScoresUrl(input.Leaderboardid, input.skip, input.limit).ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            Debug.Log(body);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<TOutput>>(body);

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body)?.Message);
        }

        public async Task<RowResponse<TOutput>> GetCurrentUserScore<TInput, TOutput>(TInput input)
           where TInput : GetCurrentUserScoreParams
           where TOutput : UserScore
        {

            var response = await WebRequest.Post(UrlMap.GetCurrentUserScoreUrl(input.LeaderboardId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<TOutput>>(body);

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body)?.Message);
        }

        public async Task<RowListResponse<UserScore>> GetFriendsScores<T>(T input) where T : GetFriendsScoresParams
        {
            var response = await WebRequest.Get(UrlMap.GetMyFriendsScoreUrl(input.LeaderboardId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            Debug.Log(body);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<UserScore>>(body);

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body)?.Message);
        }

        public async Task<RowResponse<TOutput>> SubmitScore<TInput, TOutput>(TInput input)
           where TInput : SubmitScoreParams
           where TOutput : UserScore
        {
            Debug.Log(input.ToString());
            var response = await WebRequest.Post(UrlMap.SubmitScoreUrl(input.LeaderboardId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            Debug.Log(body);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<TOutput>>(body);

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body)?.Message);
        }


    }
}