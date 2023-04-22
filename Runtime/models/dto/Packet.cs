using System;
using Newtonsoft.Json;

namespace models.dto
{
    public class Request:EventArgs
    {        
        [JsonProperty("1")]
        private string GameId { get; set; }
        [JsonProperty("2")]
        private string Protocol { get; set; }
        [JsonProperty("3")]
        public int UserId { get; set; }
        [JsonProperty("4")]
        public string Method { get; set; }
        [JsonProperty("5")]
        public string Payload { get; set; }
    }
}