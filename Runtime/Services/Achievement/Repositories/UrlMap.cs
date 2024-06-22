namespace DynamicPixels.GameService.Services.Achievement.Repositories
{
    public class UrlMap
    {
        public static string GetAchievementsUrl(bool justUnlocked, int skip, int limit) => $"/api/table/services/achievements?JustDone={justUnlocked}&skip={skip}&limit={limit}";
        public static string GetUserAchievementsUrl = "/api/table/services/achievements/me";
        public static string UnlockAchievementUrl = "/api/table/services/achievements";
    }
}