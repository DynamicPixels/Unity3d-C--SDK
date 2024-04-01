using System.IO;
using System.Threading.Tasks;
using adapters.repositories.table.services.user;
using adapters.utils.httpClient;
using models;
using models.inputs;
using models.outputs;
using Newtonsoft.Json;

namespace adapters.repositories.table.services.device
{
    public class DeviceRepository:IDeviceRepository
    {
        public async Task<RowListResponse<Device>> FindMyDevices<T>(T input) where T : FindMyDeviceParams
        {
            var response = await WebRequest.Get(UrlMap.FindMyDevicesUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<RowListResponse<Device>>(body);
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

        public async Task<ActionResponse> RevokeDevice<T>(T input) where T : RevokeDeviceParams
        {
            var response = await WebRequest.Post(UrlMap.RevokeDeviceUrl(input.DeviceId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ActionResponse>(body);
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