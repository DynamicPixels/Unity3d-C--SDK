using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace models.dto
{
    public class Leaderboard
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("desc")]
        public string Desc { get; set; }
        [JsonProperty("order")]
        public int Order { get; set; }
        [JsonProperty("course")]
        public int Course { get; set; }
        [JsonProperty("timeframe")]
        public int TimeFrame { get; set; }
        [JsonProperty("participants")]
        public int Participants { get; set; }
        [JsonProperty("round")]
        public int Round { get; set; }
        [JsonProperty("winners_count")]
        public int WinnersCount { get; set; }
        [JsonProperty("last_wipe")]
        public DateTime LastWipe { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class UserScore: BaseScore
    {
        [JsonProperty("name")]
        public string? Name { get; set; } 
        [JsonProperty("image")]
        public string? Image { get; set; }
        [JsonProperty("username")]
        public string? Username { get; set; }
        [JsonProperty("label")]
        public string? Label { get; set; }
        [JsonProperty("tags")]
        public string? Tags { get; set; }
        [JsonProperty("is_ban")]
        public bool IsBan { get; set; }
        [JsonProperty("is_tester")]
        public bool IsTester { get; set; }
        [JsonProperty("is_guest")]
        public bool IsGuest { get; set; }
        [JsonProperty("first_login")]
        public DateTime? FirstLogin { get; set; }
        [JsonProperty("last_login")]
        public DateTime? LastLogin { get; set; }
        [JsonProperty("is_me")]
        public bool IsMe { get; set; }
        [JsonProperty("is_friend")]
        public bool IsFriend { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
    
    public class PartyScore: BaseScore
    {
        [JsonProperty("name")]
        public string? Name { get; set; } 
        [JsonProperty("desc")]
        public string Desc { get; set; } = "";
        [JsonProperty("image")]
        public string? Image { get; set; }
        [JsonProperty("is_me")]
        public bool IsMe { get; set; }
        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; } = "{}";
        [JsonProperty("variables")]
        public Dictionary<string, string> Variables { get; set; } = new Dictionary<string, string>();
        [JsonProperty("owner")]
        public int Owner { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    
    public class BaseScore
    {
        [JsonProperty("value")]
        public int Value { get; set; }
        [JsonProperty("tries")]
        public int Tries { get; set; }
        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}