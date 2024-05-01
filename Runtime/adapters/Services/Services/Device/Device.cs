using System.Collections.Generic;
using System.Threading.Tasks;
using GameService.Client.Sdk.Adapters.Repositories.Services.Device;
using GameService.Client.Sdk.Models.inputs;

namespace GameService.Client.Sdk.Adapters.Services.Services.Device
{
    public class DeviceService: IDevice
    {
        private IDeviceRepository _repository;
        public DeviceService()
        {
            this._repository = new DeviceRepository();
        }

        public async Task<List<User.Device>> FindMyDevices<T>(T input) where T : FindMyDeviceParams
        {
            var result = await this._repository.FindMyDevices(input);
            return result.List;
        }

        public async Task<bool> RevokeDevice<T>(T input) where T : RevokeDeviceParams
        {
            var result = await this._repository.RevokeDevice(input);
            return result.Affected > 0;
        }
    }
}