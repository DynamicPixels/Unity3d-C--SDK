using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.Device.Models;
using DynamicPixels.GameService.Services.Device.Repositories;

namespace DynamicPixels.GameService.Services.Device
{
    public class DeviceService : IDevice
    {
        private IDeviceRepository _repository;
        public DeviceService()
        {
            _repository = new DeviceRepository();
        }

        public async Task<List<User.Models.Device>> FindMyDevices<T>(T input) where T : FindMyDeviceParams
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