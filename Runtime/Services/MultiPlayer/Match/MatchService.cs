using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DynamicPixels.GameService.Models;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Services.MultiPlayer.Match.Models;
using DynamicPixels.GameService.Utils.HttpClient;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.MultiPlayer.Match
{
    public class MatchService : IMatchService
    {
        public async Task<Match> MakeMatch(int roomId, bool lockRoom = true)
        {
            var input = new MakeMatchParams
            {
                RoomId = roomId,
                LockRoom = lockRoom
            };
            var response = await WebRequest.Post(UrlMap.MakeMatchUrl, JsonConvert.SerializeObject(input));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Match>(body);

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
        }

        public async Task<Match> MakeAndStartMatch(int roomId, bool lockRoom = true)
        {
            var input = new MakeMatchParams
            {
                RoomId = roomId,
                LockRoom = lockRoom
            };
            var response = await WebRequest.Post(UrlMap.MakeAndStartMatchUrl, JsonConvert.SerializeObject(input));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Match>(body);

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
        }

        public async Task<Match> LoadMatch(int matchId)
        {
            var response = await WebRequest.Get(UrlMap.LoadMatch(matchId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Match>(body);

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
        }

        public async Task<IEnumerable<MatchSummary>> GetMyMatches()
        {
            var response = await WebRequest.Get(UrlMap.GetMyMatchesUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<IEnumerable<MatchSummary>>(body);

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
        }
    }
}