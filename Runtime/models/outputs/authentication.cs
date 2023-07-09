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
        
        [JsonProperty("connection")]
        public ConnectionInfo Connection { get; set; }
    }

    public class ConnectionInfo
    {
        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }
        [JsonProperty("protocol")]
        public string Protocol { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
    }

    [Serializable]
    public class OtaResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}