using System;
using Newtonsoft.Json;

namespace models.dto
{
    [Serializable]
    public class User: Row
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("email")]
        public string? Email { get; set; }
        [JsonProperty("phone_number")]
        public string? PhoneNumber { get; set; }
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
        [JsonProperty("google_token")]
        public string? GoogleToken { get; set; }
        [JsonProperty("fcm_id")]
        public string? FcmId { get; set; }
        [JsonProperty("first_login")]
        public DateTime? FirstLogin { get; set; }
        [JsonProperty("last_login")]
        public DateTime? LastLogin { get; set; }

    }
}