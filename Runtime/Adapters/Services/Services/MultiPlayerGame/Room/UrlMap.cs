namespace GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame.Room
{
    public class UrlMap
    {
        private const string _baseUrl = "/api/services/multiplayer/rooms";

        public static string CreateRoomUrl = $"{_baseUrl}";
        public static string GetAllRoomsUrl = $"{_baseUrl}";
        public static string GetAllMatchedRoomsUrl = $"{_baseUrl}/matched";
        public static string AutoMatchUrl = $"{_baseUrl}/autoMatch";
        public static string GetRoomByIdUrl(int roomId) => $"{_baseUrl}/{roomId}";
        public static string GetRoomByNameUrl(string name) => $"{_baseUrl}/n/{name}";
        public static string JoinRoomByIdUrl(int roomId) => $"{_baseUrl}/{roomId}/players";
        public static string JoinRoomByNameUrl(string name) => $"{_baseUrl}/n/{name}/players";
        public static string DeleteRoomUrl(int roomId) => $"{_baseUrl}/{roomId}";
        public static string LeaveRoomUrl(int roomId) => $"{_baseUrl}/{roomId}/players";
    }
}