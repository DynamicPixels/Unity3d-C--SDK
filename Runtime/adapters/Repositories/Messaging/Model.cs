using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace models.dto
{
    public class Request:EventArgs
    {        
        [JsonProperty("1")] [CanBeNull] private string GameId { get; set; }
        [JsonProperty("2")] [CanBeNull] private string Protocol { get; set; }
        [JsonProperty("3")] public int? UserId { get; set; }
        [JsonProperty("4")]
        public string Method { get; set; }
        [JsonProperty("5")] [CanBeNull] public string Payload { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings{
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}