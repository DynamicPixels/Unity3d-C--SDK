namespace GameService.Client.Sdk.Services.Services.MultiPlayer.Room
{
    public class UrlMap
    {
        private const string _baseUrl = "/api/services/multiplayer/rooms";

        // post
        public static string CreateRoomUrl = $"{_baseUrl}";
        public static string AutoMatchUrl = $"{_baseUrl}/autoMatch";
        public static string JoinToRoomByIdUrl(int roomId) => $"{_baseUrl}/{roomId}/players";
        public static string JoinToRoomByNameUrl(string name) => $"{_baseUrl}/n/{name}/players";

        // get
        public static string GetAllRoomsUrl = $"{_baseUrl}";
        public static string GetAllMatchedRoomsUrl = $"{_baseUrl}/matched";
        public static string GetRoomByIdUrl(int roomId) => $"{_baseUrl}/{roomId}";
        public static string GetRoomByNameUrl(string name) => $"{_baseUrl}/n/{name}";

        // delete
        public static string DeleteRoomUrl(int roomId) => $"{_baseUrl}/{roomId}";
        public static string LeaveRoomUrl(int roomId) => $"{_baseUrl}/{roomId}/players";
    }
}