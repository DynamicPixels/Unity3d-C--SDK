using System.Collections.Generic;
using Newtonsoft.Json;

namespace models.dto
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
        public string Name { get; set; } = null!;
        public string Desc { get; set; } = "";
        public string Image { get; set; } = "";
        public int MaxMemberCount { get; set; }
        public bool IsPrivate { get; set; }

        public string Teams { get; set; } = "[]";
        public string Channels { get; set; } = "[]";

        public string Data { get; set; } = "{}";
        public Dictionary<string, string> Variables { get; set; } = new Dictionary<string, string>();
        public int Owner { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class PartyMember : Row
    {
        public int Party { get; set; }
        public int Player { get; set; }
        public PartyMemberRoles Role { get; set; }
        public PartyMemberStatus Status { get; set; }
        public string Data { get; set; } = null!;
        public Dictionary<string, string> Variables { get; set; } = new Dictionary<string, string>();
        public string Channels { get; set; } = "[]";
        public string Team { get; set; } = "[]";
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class RichPartyMember : User
    {
        public PartyMemberRoles Role { get; set; }
        public PartyMemberStatus Status { get; set; }
        public string Data { get; set; } = null!;
        public Dictionary<string, string> Variables { get; set; } = new Dictionary<string, string>();
        public string Channels { get; set; } = "[]";
        public string Team { get; set; } = "[]";
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}