using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Leaderboard.Models
{
    public class Leaderboard
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("desc")] public string Desc { get; set; }
        [JsonProperty("label")] public string Lable { get; set; }
        [JsonProperty("unique_by")] public string UniqueBy { get; set; }

        [JsonProperty("actions")] public string Actions { get; set; } = "[]";
        [JsonProperty("extend_table")] public string ExtendTable { get; set; }

        [JsonProperty("course")] public int Course { get; set; }
        [JsonProperty("timeframe")] public int TimeFrame { get; set; }
        [JsonProperty("ttl")] public int Ttl { get; set; }
        [JsonProperty("round")] public int Round { get; set; }
        [JsonProperty("winners_count")] public int WinnersCount { get; set; }
        [JsonProperty("last_wipe")] public DateTime LastWipe { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class UserScore : BaseScore
    {
        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("image", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("username", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty("label", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("tags", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Tags { get; set; }

        [JsonProperty("is_ban", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsBan { get; set; }

        [JsonProperty("is_tester", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsTester { get; set; }

        [JsonProperty("is_guest", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsGuest { get; set; }

        [JsonProperty("first_login", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? FirstLogin { get; set; }

        [JsonProperty("last_login", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? LastLogin { get; set; }

        [JsonProperty("is_me", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsMe { get; set; }

        [JsonProperty("is_friend", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsFriend { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }

    public class PartyScore : BaseScore
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("desc")] public string Desc { get; set; } = "";
        [JsonProperty("image")] public string Image { get; set; }
        [JsonProperty("is_me")] public bool IsMe { get; set; }
        [JsonProperty("is_private")] public bool IsPrivate { get; set; }
        [JsonProperty("data")] public string Data { get; set; } = "{}";

        [JsonProperty("variables")]
        public Dictionary<string, string> Variables { get; set; } = new Dictionary<string, string>();

        [JsonProperty("owner")] public int Owner { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class BaseScore
    {
        [JsonProperty("value", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Value { get; set; }

        [JsonProperty("tries", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Tries { get; set; }

        [JsonProperty("rank", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Rank { get; set; }
    }
}