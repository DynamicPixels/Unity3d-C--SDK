using System;
using DynamicPixels.GameService.Services.Table;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Friendship.Models
{
    public class Friendship : SlimUser
    {
        public int PairOne { get; set; }
        public int PairTwo { get; set; }
        public int Status { get; set; }
        public DateTime? AcceptedAt { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class SlimUser : Row
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("tags")]
        public string Tags { get; set; }
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

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}