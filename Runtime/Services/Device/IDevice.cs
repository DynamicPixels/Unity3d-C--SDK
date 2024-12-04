using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.Device.Models;

namespace DynamicPixels.GameService.Services.Device
{
    public interface IDevice
    {
        Task<List<User.Models.Device>> FindMyDevices<T>(T param) where T : FindMyDeviceParams;
        Task<bool> RevokeDevice<T>(T param) where T : RevokeDeviceParams;
    }
}