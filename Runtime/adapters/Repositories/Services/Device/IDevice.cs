using System.Threading.Tasks;
using adapters.repositories.table.services.user;
using models.inputs;
using models.outputs;

namespace adapters.repositories.table.services.device
{
    public interface IDeviceRepository
    {
        Task<RowListResponse<Device>> FindMyDevices<T>(T param) where T: FindMyDeviceParams;
        Task<ActionResponse> RevokeDevice<T>(T param) where T: RevokeDeviceParams;
    }
}