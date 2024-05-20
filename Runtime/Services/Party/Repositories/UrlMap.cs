namespace DynamicPixels.GameService.Services.Party.Repositories
{
    public class UrlMap
    {
        public const string GetPartiesUrl = "/api/table/services/parties";
        public const string CreatePartyUrl = "/api/table/services/parties";
        public const string GetSubscribedPartiesUrl = "/api/table/services/parties/me";
        public static string GetPartyByIdUrl(int partyId) => $"/api/table/services/parties/{partyId}";
        public static string JoinToPartyUrl(int partyId) => $"/api/table/services/parties/{partyId}";
        public static string EditPartyUrl(int partyId) => $"/api/table/services/parties/{partyId}";
        public static string LeavePartyUrl(int partyId) => $"/api/table/services/parties/{partyId}";
        public static string GetPartyMembersUrl(int partyId) => $"/api/table/services/parties/{partyId}/members";
        public static string GetPartyWaitingMembersUrl(int partyId) => $"/api/table/services/parties/{partyId}/waiting";
        public static string AcceptJoiningUrl(int partyId, int membershipId) => $"/api/table/services/parties/{partyId}/waiting/{membershipId}";
        public static string RejectJoiningUrl(int partyId, int membershipId) => $"/api/table/services/parties/{partyId}/waiting/{membershipId}";
    }
}