using System;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Authentication.Models
{
    [Serializable]
    public class LoginWithGoogleParams
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("device_info")]
        public readonly User.Models.Device DeviceInfo = new User.Models.Device(ServiceHub.SystemInfo);

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}