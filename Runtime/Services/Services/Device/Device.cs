using System.Collections.Generic;
using System.Threading.Tasks;
using GameService.Client.Sdk.Models.inputs;
using GameService.Client.Sdk.Repositories.Services.Device;

namespace GameService.Client.Sdk.Services.Services.Device
{
    public class DeviceService : IDevice
    {
        private IDeviceRepository _repository;
        public DeviceService()
        {
            _repository = new DeviceRepository();
        }

        public async Task<List<User.Device>> FindMyDevices<T>(T input) where T : FindMyDeviceParams
        {
            var result = await _repository.FindMyDevices(input);
            return result.List;
        }

        public async Task<bool> RevokeDevice<T>(T input) where T : RevokeDeviceParams
        {
            var result = await _repository.RevokeDevice(input);
            return result.Affected > 0;
        }
    }
}