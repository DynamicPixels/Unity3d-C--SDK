using System.Collections.Generic;
using System.Threading.Tasks;
using adapters.repositories.table.services.device;
using models.dto;
using models.inputs;
using models.outputs;

namespace adapters.services.table.services
{
    public class DeviceService: IDevice
    {
        private IDeviceRepository _repository;
        public DeviceService()
        {
            this._repository = new DeviceRepository();
        }

        public async Task<List<Device>> FindMyDevices<T>(T input) where T : FindMyDeviceParams
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