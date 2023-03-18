namespace adapters.repositories.table.services.leaderboard
{
    public class UrlMap
    {
        public const string GetLeaderboardsUrl = "api/table/services/leaderboard";
        public static string GetScoresUrl(string leaderboardId) => $"api/table/services/leaderboard/{leaderboardId}";
        public static string GetCurrentUserScoreUrl(string leaderboardId) => $"api/table/services/leaderboard/{leaderboardId}/me";
        public static string GetMyFriendsScoreUrl(string leaderboardId) => $"api/table/services/leaderboard/{leaderboardId}/friends";
        public static string SubmitScoreUrl(string leaderboardId) => $"api/table/services/leaderboard/{leaderboardId}";
    }
}