using System.Threading.Tasks;
using GameService.Client.Sdk.Models.inputs;
using GameService.Client.Sdk.Models.outputs;

namespace GameService.Client.Sdk.Adapters.Repositories.Services.Device
{
    public interface IDeviceRepository
    {
        Task<RowListResponse<Adapters.Services.Services.User.Device>> FindMyDevices<T>(T param) where T: FindMyDeviceParams;
        Task<ActionResponse> RevokeDevice<T>(T param) where T: RevokeDeviceParams;
    }
}