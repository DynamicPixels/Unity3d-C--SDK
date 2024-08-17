using System.Threading.Tasks;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Services.Device.Models;
using DynamicPixels.GameService.Utils.HttpClient;

namespace DynamicPixels.GameService.Services.Device.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        public Task<RowListResponse<User.Models.Device>> FindMyDevices<T>(T input) where T : FindMyDeviceParams
        {
            return WebRequest.Get<RowListResponse<User.Models.Device>>(UrlMap.FindMyDevicesUrl);
        }

        public Task<ActionResponse> RevokeDevice<T>(T input) where T : RevokeDeviceParams
        {
            return WebRequest.Post<ActionResponse>(UrlMap.RevokeDeviceUrl(input.DeviceId), input.ToString());
        }
    }
}