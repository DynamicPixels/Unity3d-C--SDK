using System.Collections.Generic;
using DynamicPixels.GameService.Services.Chat.Repositories;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Chat.Models
{
    public class Payload
    {
        [JsonProperty("target_id")] public int TargetId { get; set; }

        [JsonProperty("sub_target_id")] public int SubTargetId { get; set; }

        [JsonProperty("message_id")] public int MessageId { get; set; }

        [JsonProperty("payload")] public Message? Message { get; set; }

        [JsonProperty("value")] public string Value { get; set; } = "";

        [JsonProperty("skip")] public int Skip { get; set; }

        [JsonProperty("limit")] public int Limit { get; set; }

        [JsonProperty("properties")] public Dictionary<string, string>? properties { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}