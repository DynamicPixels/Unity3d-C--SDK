using System.IO;
using System.Threading.Tasks;
using adapters.utils.httpClient;
using models;
using System.IO;
using System.Threading.Tasks;
using models.outputs;
using adapters.utils.httpClient;
using ports;
using models;
using models.inputs;
using Newtonsoft.Json;
using UnityEngine;
using System;
namespace adapters.repositories.synchronise
{
    public class SynchroniseRepository: ISynchroniseRepositories
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


            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body).ToString());        
        }
        private DateTime ConvertUnixTimestampToDateTime(long timestamp)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(timestamp);
        }
    }
   
}