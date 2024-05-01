using System.Collections.Generic;
using System.Threading.Tasks;
using GameService.Client.Sdk.Models.inputs;

namespace GameService.Client.Sdk.Adapters.Services.Services.Device
{
    public interface IDevice
    {
        Task<List<User.Device>> FindMyDevices<T>(T param) where T: FindMyDeviceParams;
        Task<bool> RevokeDevice<T>(T param) where T: RevokeDeviceParams;
    }
}