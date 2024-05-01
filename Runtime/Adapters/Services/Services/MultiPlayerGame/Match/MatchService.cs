using System.IO;
using System.Threading.Tasks;
using GameService.Client.Sdk.Adapters.Utils.HttpClient;
using GameService.Client.Sdk.Models;
using GameService.Client.Sdk.Models.outputs;
using Newtonsoft.Json;

namespace GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame.Match
{
    public class MatchService : IMatchService
    {
        public async Task<Match> MakeMatch(int roomId)
        {
            var response = await WebRequest.Post(UrlMap.MakeMatchUrl, $"{{roomId: {roomId}}}");
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<Match>>(body)!.Row;

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
        }

        public async Task<Match> MakeAndStartMatch(int roomId)
        {
            var response = await WebRequest.Post(UrlMap.MakeAndStartMatchUrl, $"{{roomId: {roomId}}}");
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<Match>>(body)!.Row;

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
        }

        public async Task<Match> GetMatchById(int matchId)
        {
            var response = await WebRequest.Get(UrlMap.GetMatchByIdUrl(matchId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<Match>>(body)!.Row;

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
        }
    }
}