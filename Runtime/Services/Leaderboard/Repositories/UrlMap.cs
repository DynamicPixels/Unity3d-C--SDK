namespace DynamicPixels.GameService.Services.Leaderboard.Repositories
{
    public class UrlMap
    {
        public static string GetLeaderboardsUrl(int skip, int limit, string label) => $"/api/table/services/leaderboard/?skip={skip}&limit={limit}&label={label}";
        public static string GetUsersScoresUrl(int leaderboardId, int skip, int limit) => $"/api/table/services/leaderboard/user/{leaderboardId}?skip={skip}&limit={limit}";

        public static string GetPartiesScoresUrl(int leaderboardId, int skip, int limit) => $"/api/table/services/leaderboard/party/{leaderboardId}?skip={skip}&limit={limit}";
        public static string GetCurrentUserScoreUrl(int leaderboardId) => $"/api/table/services/leaderboard/{leaderboardId}/me";
        public static string GetMyFriendsScoreUrl(int leaderboardId) => $"/api/table/services/leaderboard/{leaderboardId}/friends";
        public static string SubmitScoreUrl(int leaderboardId) => $"/api/table/services/leaderboard/{leaderboardId}";
    }
}