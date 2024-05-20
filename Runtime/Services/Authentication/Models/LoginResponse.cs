using System;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Authentication.Models
{
    [Serializable]
    public class LoginResponse
    {
        [JsonProperty("user")]
        public User.Models.User User { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
        
        [JsonProperty("connection")]
        public ConnectionInfo Connection { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}