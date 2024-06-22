using System.IO;
using System.Threading.Tasks;
using DynamicPixels.GameService.Models;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Services.Device.Models;
using DynamicPixels.GameService.Utils.HttpClient;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Device.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        public async Task<RowListResponse<User.Models.Device>> FindMyDevices<T>(T input) where T : FindMyDeviceParams
        {
            var response = await WebRequest.Get(UrlMap.FindMyDevicesUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<RowListResponse<User.Models.Device>>(body);
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