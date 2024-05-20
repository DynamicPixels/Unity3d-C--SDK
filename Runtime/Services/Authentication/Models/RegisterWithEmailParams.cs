using System;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Authentication.Models
{
    [Serializable]
    public class RegisterWithEmailParams
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("device_info")]
        public readonly User.Models.Device DeviceInfo = new User.Models.Device(ServiceHub.SystemInfo);

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}