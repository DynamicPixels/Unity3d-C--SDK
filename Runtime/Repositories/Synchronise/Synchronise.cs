using System;
using System.IO;
using System.Threading.Tasks;
using GameService.Client.Sdk.Models;
using GameService.Client.Sdk.Models.outputs;
using GameService.Client.Sdk.Utils.HttpClient;
using Newtonsoft.Json;

namespace GameService.Client.Sdk.Repositories.Synchronise
{
    public class SynchroniseRepository : ISynchroniseRepositories
    {
        public async Task<DateTime> GetServerTime()
        {
            var response = await WebRequest.Get(UrlMap.GetServerTimeUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
            {
                var timestamp = JsonConvert.DeserializeObject<RowResponse<long>>(body).Row;
                var serverTime = ConvertUnixTimestampToDateTime(timestamp);
                return serverTime;
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
        private DateTime ConvertUnixTimestampToDateTime(long timestamp)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(timestamp);
        }
    }

}