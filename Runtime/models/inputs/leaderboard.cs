using Newtonsoft.Json;
using models.inputs.QueryHelper;
using System.Collections.Generic;
namespace models.inputs
{
    public class GetLeaderboardsParams
    {
        
    }

    public class GetScoresParams
    {
        public int Leaderboardid;

        public int skip;
        public int limit;
        [JsonProperty("return_me")]
        public bool return_me;
        [JsonProperty("conditions", NullValueHandling = NullValueHandling.Ignore)]
        public QueryParam? Conditions { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class GetCurrentUserScoreParams
    {
        public int LeaderboardId { get; set; }
        public QueryParam? Conditions { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class GetFriendsScoresParams
    {
        public int LeaderboardId { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }

    public class SubmitScoreParams
    {
        public int LeaderboardId { get; set; }


        [JsonProperty("score", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Score { get; set; }
        [JsonProperty("other_data", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Dictionary<string, dynamic>? OtherData { get; set; }
        [JsonProperty("party_Id",DefaultValueHandling =DefaultValueHandling.Ignore)]
        public int PartyId { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}