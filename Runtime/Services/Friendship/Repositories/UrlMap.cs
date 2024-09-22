namespace DynamicPixels.GameService.Services.Friendship.Repositories
{
    public class UrlMap
    {
        public const string GetMyFriendsUrl = "/api/table/services/friendship";
        public const string GetMyFriendshipRequestsUrl = "/api/table/services/friendship/request";
        public const string RequestFriendshipUrl = "/api/table/services/friendship/request";
        public static string AcceptRequestUrl(int requestId) => $"/api/table/services/friendship/request/{requestId}";
        public static string RejectRequestUrl(int requestId) => $"/api/table/services/friendship/request/{requestId}";
        public const string RejectAllRequestsUrl = "/api/table/services/friendship/request";
        public static string DeleteFriendUrl(int userId) => $"/api/table/services/friendship/{userId}";
    }
}