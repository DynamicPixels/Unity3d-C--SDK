using System;
using System.Threading.Tasks;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Utils.HttpClient;

namespace DynamicPixels.GameService.Services.Synchronise.Repositories
{
    public class SynchroniseRepository : ISynchroniseRepositories
    {
        public async Task<DateTime> GetServerTime()
        {
            var response = await WebRequest.Get<RowResponse<long>>(UrlMap.GetServerTimeUrl);
            return ConvertUnixTimestampToDateTime(response.Row);
        }
        private DateTime ConvertUnixTimestampToDateTime(long timestamp)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(timestamp);
        }
    }

}