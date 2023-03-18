using System;
using models.dto;
using Newtonsoft.Json;

namespace models.outputs
{
    [Serializable]
    public class LoginResponse
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }

    [Serializable]
    public class OtaResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}