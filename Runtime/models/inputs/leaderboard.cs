namespace models.inputs
{
    public class GetLeaderboardsParams
    {
        
    }

    public class GetScoresParams
    {
        public string LeaderboardId { get; set; }
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
    }
}