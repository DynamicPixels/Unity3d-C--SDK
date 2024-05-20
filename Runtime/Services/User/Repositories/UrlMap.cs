namespace DynamicPixels.GameService.Services.User.Repositories
{
    public class UrlMap
    {
        public const string FindUsersUrl = "/api/table/services/users/find";
        public const string GetCurrentUserUrl = "/api/table/services/users";
        public static string FindUserByIdUrl(int userId) => $"/api/table/services/users/{userId}";
        public const string EditCurrentUserUrl = "/api/table/services/users";
        public static string BanUserByIdUrl(int userId) => $"/api/table/services/users/{userId}";
    }
}