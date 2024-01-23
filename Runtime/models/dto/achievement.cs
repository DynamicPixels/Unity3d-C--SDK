
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
namespace models.dto
{
    public class Achievement : Row
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        [JsonProperty("desc")]
        public string Desc { get; set; } = null!;
        [JsonProperty("image")]
        public string Image { get; set; } = "";

        [JsonProperty("extend_table",DefaultValueHandling=DefaultValueHandling.Ignore)] public string? ExtendTable { get; set; } = "";

        [JsonProperty("step_extend_table")]
        public string StepExtendTable { get; set; } = "";

        [JsonProperty("start_at")]
        public DateTime StartAt { get; set; }
        [JsonProperty("end_at")]
        public DateTime EndAt { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class BaseAchievement : Achievement
    {
        [JsonProperty("step_id")]
        public int StepId { get; set; }

        [JsonProperty("step_name")]
        public string StepName { get; set; }

        [JsonProperty("step_point")]
        public int StepPoint { get; set; }

        [JsonProperty("player")]
        public int Player { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class RichAchievement : Achievement
    {
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

    public class RichStep : Achievement
    {
        [JsonProperty("step_id")]
        public int StepId { get; set; }
        [JsonProperty("step_name")]
        public string StepName { get; set; }
        [JsonProperty("step_point")]
        public int StepPoint { get; set; }
        [JsonProperty("step_payload")]
        public string StepPayload { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class RichUnlock : Row
    {
        [JsonProperty("player")]
        public int Player { get; set; }
        [JsonProperty("achievement")]
        public int Achievement { get; set; }
        [JsonProperty("step")]
        public int Step { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        [JsonProperty("image")]
        public string Image { get; set; } = "";
        [JsonProperty("steps")]
        public int Steps { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}