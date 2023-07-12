
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

namespace adapters.repositories.table.services.device
{
    public class DeviceRepository:IDeviceRepository
    {
        public async Task<RowListResponse<Device>> FindMyDevices<T>(T input) where T : FindMyDeviceParams
        {
            var response = await WebRequest.Get(UrlMap.FindMyDevicesUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<Device>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<ActionResponse> RevokeDevice<T>(T input) where T : RevokeDeviceParams
        {
            var response = await WebRequest.Post(UrlMap.RevokeDeviceUrl(input.DeviceId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ActionResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }
    }
}