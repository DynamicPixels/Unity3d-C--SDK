using System.Threading.Tasks;
using GameService.Client.Sdk.Models.inputs;
using GameService.Client.Sdk.Models.outputs;

namespace GameService.Client.Sdk.Repositories.Services.Device
{
    public interface IDeviceRepository
    {
        Task<RowListResponse<Sdk.Services.Services.User.Device>> FindMyDevices<T>(T param) where T : FindMyDeviceParams;
        Task<ActionResponse> RevokeDevice<T>(T param) where T : RevokeDeviceParams;
    }
}