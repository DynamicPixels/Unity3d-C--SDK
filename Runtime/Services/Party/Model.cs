using System.Collections.Generic;
using DynamicPixels.GameService.Services.Table;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Party
{

    public enum PartyMemberStatus
    {
        Waiting = 0,
        Accepted = 1
    }

    public enum PartyMemberRoles
    {
        Owner = 1,
        Admin = 2,
        Member = 3
    }

    public class Party : Row
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        [JsonProperty("desc")]
        public string Desc { get; set; } = "";
        [JsonProperty("image")]
        public string Image { get; set; } = "";
        [JsonProperty("max_member_count")]
        public int MaxMemberCount { get; set; }
        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("teams")]
        public string Teams { get; set; } = "[]";
        [JsonProperty("channels")]
        public string Channels { get; set; } = "[]";

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

    public class PartyMember : Row
    {
        [JsonProperty("party")]
        public int Party { get; set; }
        [JsonProperty("player")]
        public int Player { get; set; }
        [JsonProperty("role")]
        public PartyMemberRoles Role { get; set; }
        [JsonProperty("status")]
        public PartyMemberStatus Status { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; } = null!;
        [JsonProperty("variables")]
        public Dictionary<string, string> Variables { get; set; } = new Dictionary<string, string>();
        [JsonProperty("channels")]
        public string Channels { get; set; } = "[]";
        [JsonProperty("team")]
        public string Team { get; set; } = "[]";

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class RichPartyMember : User.Models.User
    {
        [JsonProperty("role")]
        public PartyMemberRoles Role { get; set; }
        [JsonProperty("status")]
        public PartyMemberStatus Status { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; } = null!;
        [JsonProperty("variables")]
        public Dictionary<string, string> Variables { get; set; } = new Dictionary<string, string>();
        [JsonProperty("channels")]
        public string Channels { get; set; } = "[]";
        [JsonProperty("team")]
        public string Team { get; set; } = "[]";

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}