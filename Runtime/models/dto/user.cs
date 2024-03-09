using Newtonsoft.Json;

namespace models.dto
{
    [Serializable]
    public class User: Row
    {
        [JsonProperty("name")] [CanBeNull] public string Name { get; set; }
        [JsonProperty("email")] [CanBeNull] public string Email { get; set; }
        [JsonProperty("phone_number")] [CanBeNull] public string PhoneNumber { get; set; }
        [JsonProperty("image")] [CanBeNull] public string Image { get; set; }
        [JsonProperty("username")] [CanBeNull] public string Username { get; set; }
        [JsonProperty("label")] [CanBeNull] public string Label { get; set; }
        [JsonProperty("tags")] [CanBeNull] public string Tags { get; set; }
        [JsonProperty("is_ban")]
        public bool IsBan { get; set; }
        [JsonProperty("is_tester")]
        public bool IsTester { get; set; }
        [JsonProperty("is_guest")]
        public bool IsGuest { get; set; }
        [JsonProperty("google_token")] [CanBeNull] public string GoogleToken { get; set; }
        [JsonProperty("fcm_id")] [CanBeNull] public string FcmId { get; set; }
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