namespace adapters.repositories.table.services
{
    public class UrlMap
    {
        public static string GetConversationMessagesUrl(int conversationId) => $"/api/table/services/chats/{conversationId}";
        public static string GetConversationMembersUrl(int conversationId) => $"/api/table/services/chats/{conversationId}/member";
        public const string GetSubscribedConversationsUrl = "/api/table/services/chats";

    }
}