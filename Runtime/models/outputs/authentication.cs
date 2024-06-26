using System;
using adapters.repositories.table.services.user;
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
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ConnectionInfo
    {
        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }
        [JsonProperty("protocol")]
        public string Protocol { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    [Serializable]
    public class OtaResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    
}