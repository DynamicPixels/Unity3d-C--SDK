
using System;
using System.IO;
using System.Threading.Tasks;
using adapters.utils.httpClient;
using models;
using models.dto;
using models.inputs;
using models.outputs;
using Newtonsoft.Json;

namespace adapters.repositories.table.services.leaderboard
{
    public class LeaderboardRepository : ILeaderboardRepository
    {

        public async Task<RowListResponse<Leaderboard>> GetLeaderBoards<T>(T input) where T : GetLeaderboardsParams
        {
            
            var response = await WebRequest.Get(UrlMap.GetLeaderboardsUrl(input.skip,input.limit,input.label));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<RowListResponse<Leaderboard>>(body);
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

        public async Task<RowListResponse<TOutput>> GetPartiesScores<TInput, TOutput>(TInput input)
           where TInput : GetScoresParams
           where TOutput : PartyScore
        {
            var response = await WebRequest.Post(UrlMap.GetPartiesScoresUrl(input.Leaderboardid, input.skip, input.limit), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<RowListResponse<TOutput>>(body);
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

        public async Task<RowListResponse<TOutput>> GetUsersScores<TInput, TOutput>(TInput input)
            where TInput : GetScoresParams
            where TOutput : UserScore
        {

            var response = await WebRequest.Post(UrlMap.GetUsersScoresUrl(input.Leaderboardid, input.skip, input.limit), input.ToString());

            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<RowListResponse<TOutput>>(body);
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
            public async Task<RowResponse<TOutput>> GetCurrentUserScore<TInput, TOutput>(TInput input)
           where TInput : GetCurrentUserScoreParams
           where TOutput : UserScore
        {

            var response = await WebRequest.Post(UrlMap.GetCurrentUserScoreUrl(input.LeaderboardId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<RowResponse<TOutput>>(body);
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

        public async Task<RowListResponse<UserScore>> GetFriendsScores<T>(T input) where T : GetFriendsScoresParams
        {
            var response = await WebRequest.Get(UrlMap.GetMyFriendsScoreUrl(input.LeaderboardId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<RowListResponse<UserScore>>(body);
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

        public async Task<RowResponse<TOutput>> SubmitScore<TInput, TOutput>(TInput input)
           where TInput : SubmitScoreParams
           where TOutput : UserScore
        {
            var response = await WebRequest.Post(UrlMap.SubmitScoreUrl(input.LeaderboardId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<RowResponse<TOutput>>(body);
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