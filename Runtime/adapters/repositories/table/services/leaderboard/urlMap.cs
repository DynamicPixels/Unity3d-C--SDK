namespace adapters.repositories.table.services.leaderboard
{
    public class UrlMap
    {
        public const string GetLeaderboardsUrl = "/api/table/services/leaderboard";
        public static string GetUsersScoresUrl(int leaderboardId) => $"/api/table/services/leaderboard/user/{leaderboardId}";
        public static string GetPartiesScoresUrl(int leaderboardId) => $"/api/table/services/leaderboard/party/{leaderboardId}";
        public static string GetCurrentUserScoreUrl(int leaderboardId) => $"/api/table/services/leaderboard/{leaderboardId}/me";
        public static string GetMyFriendsScoreUrl(int leaderboardId) => $"/api/table/services/leaderboard/{leaderboardId}/friends";
        public static string SubmitScoreUrl(int leaderboardId) => $"/api/table/services/leaderboard/{leaderboardId}";
    }
}