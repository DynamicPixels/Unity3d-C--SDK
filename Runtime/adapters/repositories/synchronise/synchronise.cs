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

namespace adapters.repositories.synchronise
{
    public class SynchroniseRepository: ISynchroniseRepositories
    {
        public async Task<long> GetServerTime()
        {
            var response = await WebRequest.Get(UrlMap.GetServerTimeUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<long>>(body).Row;

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body).ToString());        
        }
    }
}