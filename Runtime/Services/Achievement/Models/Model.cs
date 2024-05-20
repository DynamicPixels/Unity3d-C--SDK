using System;
using System.Collections.Generic;
using DynamicPixels.GameService.Services.Table;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Achievement.Models
{
    public class Achievement : Row
    {
        [JsonProperty("name")] public string Name { get; set; } = null!;
        [JsonProperty("desc")] public string Desc { get; set; } = null!;
        [JsonProperty("image")] public string Image { get; set; } = "";

        [JsonProperty("extend_table", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ExtendTable { get; set; } = "";

        [JsonProperty("step_extend_table")] public string StepExtendTable { get; set; } = "";

        [JsonProperty("start_at")] public DateTime StartAt { get; set; }
        [JsonProperty("end_at")] public DateTime EndAt { get; set; }
        [JsonProperty("steps")]
        public List<dynamic> Steps { get; set; } = new();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Unlock : Row
    {
        [JsonProperty("player")]
        public int Player { get; set; }
        [JsonProperty("achievement")]
        public int Achievement { get; set; }
        [JsonProperty("step")]
        public int Step { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Step : Row
    {
        [JsonProperty("achievement")]
        public int Achievement { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("point")]
        public int Point { get; set; }
        [JsonProperty("payload")]
        public string Payload { get; set; }
        [JsonProperty("unlocked")]
        public bool Unlocked { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}