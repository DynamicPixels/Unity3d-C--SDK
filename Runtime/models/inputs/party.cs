using System.Collections.Generic;
using models.dto;
using Newtonsoft.Json;

namespace models.inputs
{
    public class PartyInput
    {
        public string Name { get; set; } = null!;
        public string Desc { get; set; } = "";
        public string Image { get; set; } = "";
        public int MaxMemberCount { get; set; }
        public bool IsPrivate { get; set; } = false;

        public string[] Teams { get; set; } = new string[]{};
        public string[] Channels { get; set; } = new string[]{};

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
        public Party Party;
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