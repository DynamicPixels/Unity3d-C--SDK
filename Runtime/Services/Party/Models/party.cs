using System.Collections.Generic;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Party.Models
{
    public class PartyInput
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        [JsonProperty("desc")]
        public string Desc { get; set; } = "";
//        public string Image { get; set; } = "";
        [JsonProperty("max_member_count")]
        public int MaxMemberCount { get; set; }
        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; } = false;

        [JsonProperty("teams")]
        public string[] Teams { get; set; } = new string[]{};
        [JsonProperty("channels")]
        public string[] Channels { get; set; } = new string[]{};

        [JsonProperty("variables")]
        public Dictionary<string, string> Variables { get; set; } = new Dictionary<string, string>();
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    
    public class GetPartiesParams
    {
        public string? Query;
        public int Skip;
        public int Limit;
    }

    public class CreatePartyParams
    {
        public PartyInput Data;
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class GetSubscribedPartiesParams
    {
        public string Query;
        public int Skip;
        public int Limit;
    }

    public class JoinToPartyParams
    {
        public  int PartyId;
        public  string Team;
        public  string[] Channels;
    }

    public class LeavePartyParams
    {
        public int PartyId;
    }

    public class GetPartyByIdParams
    {
        public int PartyId;
    }

    public class GetPartyMembersParams
    {
        public int PartyId;
        public int Skip;
        public int Limit;
    }

    public class SetMemberVariablesParams
    {
        public int PartyId;
        public Dictionary<string, string> Data;
    }

    public class GetPartyWaitingMembersParams
    {
        public int PartyId;
        public int Skip;
        public int Limit;
    }

    public class EditPartyParams
    {
        public int PartyId;
        public PartyInput Party;
    }

    public class AcceptJoiningParams
    {
        public int PartyId;
        public int MembershipId;
    }
    
    public class RejectJoiningParams
    {
        public int PartyId;
        public int MembershipId;
    }
}