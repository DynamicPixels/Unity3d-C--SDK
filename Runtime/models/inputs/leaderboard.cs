using Newtonsoft.Json;

namespace models.inputs
{
    public class GetLeaderboardsParams
    {
        
    }

    public class GetScoresParams
    {
        public string LeaderboardId { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }

    public class GetCurrentUserScoreParams
    {
        public string LeaderboardId { get; set; }
    }

    public class GetFriendsScoresParams
    {
        public string LeaderboardId { get; set; }
    }

    public class SubmitScoreParams
    {
        public string LeaderboardId { get; set; }
        public int Score { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}