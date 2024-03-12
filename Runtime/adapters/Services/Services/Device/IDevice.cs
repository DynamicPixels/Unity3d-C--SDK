using System.Collections.Generic;
using System.Threading.Tasks;
using models.dto;
using models.inputs;
using models.outputs;

namespace adapters.services.table.services
{
    public interface IDevice
    {
        Task<List<Device>> FindMyDevices<T>(T param) where T: FindMyDeviceParams;
        Task<bool> RevokeDevice<T>(T param) where T: RevokeDeviceParams;
    }
}