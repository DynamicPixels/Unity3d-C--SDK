using System.Collections.Generic;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.User.Models
{
    public class FindUserParams
    {
        public Dictionary<string, string> Query { get; set; }
    }

    public class FindUserByIdParams
    {
        public int UserId { get; set; }
    }

    public class EditCurrentUserParams
    {
        [JsonProperty("data")]
        public UserEditParams Data { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);

        }
    }
    public class UserEditParams
    {
        [JsonProperty("name")] public string? Name { get; set; }
        [JsonProperty("email")] public string? Email { get; set; }
        [JsonProperty("phone_number")] public string? PhoneNumber { get; set; }
        [JsonProperty("image")] public string? Image { get; set; }
        [JsonProperty("username")] public string? Username { get; set; }
        [JsonProperty("label")] public string? Label { get; set; }
        [JsonProperty("tags")] public string? Tags { get; set; }
        [JsonProperty("is_guest")] internal bool? IsGuest { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);

        }

    }


    public class BanUserByIdParams
    {
        public int UserId { get; set; }
        public bool Status { get; set; }
    }
    
}