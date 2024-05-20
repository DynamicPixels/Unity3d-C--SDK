using System.Threading.Tasks;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Services.Device.Models;

namespace DynamicPixels.GameService.Services.Device.Repositories
{
    public interface IDeviceRepository
    {
        Task<RowListResponse<User.Models.Device>> FindMyDevices<T>(T param) where T : FindMyDeviceParams;
        Task<ActionResponse> RevokeDevice<T>(T param) where T : RevokeDeviceParams;
    }
}