using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.Device.Models;
using DynamicPixels.GameService.Services.Device.Repositories;

namespace DynamicPixels.GameService.Services.Device
{
    /// <summary>
    /// Provides services for managing devices, including finding associated devices and revoking access.
    /// </summary>
    public class DeviceService : IDevice
    {
        private IDeviceRepository _repository;
        public DeviceService()
        {
            _repository = new DeviceRepository();
        }

        /// <summary>
        /// Retrieves the list of devices associated with the current user.
        /// </summary>
        /// <typeparam name="T">The type of the input parameters.</typeparam>
        /// <param name="input">The parameters used to filter devices.</param>
        /// <returns>
        /// A task representing the asynchronous operation, with a result containing a list of the user's devices.
        /// </returns>
        public async Task<List<User.Models.Device>> FindMyDevices<T>(T input) where T : FindMyDeviceParams
        {
            var result = await _repository.FindMyDevices(input);
            return result.List;
        }

        /// <summary>
        /// Revokes access for a specific device based on the provided parameters.
        /// </summary>
        /// <typeparam name="T">The type of the input parameters.</typeparam>
        /// <param name="input">The parameters identifying the device to revoke.</param>
        /// <returns>
        /// A task representing the asynchronous operation, with a result indicating whether the device was successfully revoked.
        /// </returns>
        public async Task<bool> RevokeDevice<T>(T input) where T : RevokeDeviceParams
        {
            var result = await _repository.RevokeDevice(input);
            return result.Affected > 0;
        }
    }
}
