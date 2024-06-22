using System;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Models
{
    public class Request : EventArgs
    {
        [JsonProperty("1", NullValueHandling = NullValueHandling.Ignore)]
        private string GameId { get; set; }
        [JsonProperty("2", NullValueHandling = NullValueHandling.Ignore)] private string Protocol { get; set; }
        [JsonProperty("3")] public int? ReceiverId { get; set; }
        [JsonProperty("4")]
        public string Method { get; set; }
        [JsonProperty("5", NullValueHandling = NullValueHandling.Ignore)] public string Payload { get; set; }
        [JsonProperty("6")] public int? SenderId { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}