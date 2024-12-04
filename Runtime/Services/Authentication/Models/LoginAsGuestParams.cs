using System;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Authentication.Models
{
    [Serializable]
    public class LoginAsGuestParams
    {

        [JsonProperty("device_id")]
        public string deviceId = "";
        [JsonProperty("name")]
        public string name = "";
        [JsonProperty("device_info")]
        public readonly User.Models.Device DeviceInfo = new User.Models.Device(ServiceHub.SystemInfo);

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}