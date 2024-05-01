namespace GameService.Client.Sdk.Adapters.Services.Services.MultiPlayerGame.Match
{
    public class UrlMap
    {
        private const string _baseUrl = "/api/services/multiplayer/matches";

        // post
        public static string MakeMatchUrl = $"{_baseUrl}";
        public static string MakeAndStartMatchUrl = $"{_baseUrl}/makeAndStart";
        
        // get
        public static string GetMatchByIdUrl(int matchId) => $"{_baseUrl}/{matchId}";

        //put
        public static string SaveUrl(int matchId) => $"{_baseUrl}/{matchId}";
        public static string SavePlayerMetaDataUrl(int matchId) => $"{_baseUrl}/{matchId}/players";
        public static string FinishUrl(int matchId) => $"{_baseUrl}/{matchId}/finish";

        // patch
        public static string UpdateMatchStatusUrl(int matchId) => $"{_baseUrl}/{matchId}";

        // delete
        public static string LeaveAndAbortUrl(int matchId) => $"{_baseUrl}/{matchId}/players";

    }
}