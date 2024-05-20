using System;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Authentication.Models
{
    [Serializable]
    public class VerifyOtaTokenParams
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; } 
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("device_info")]
        public readonly User.Models.Device DeviceInfo = new User.Models.Device(ServiceHub.SystemInfo);
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}