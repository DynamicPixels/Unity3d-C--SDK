namespace DynamicPixels.Services.Chat
{
    public partial class MessageType
    {
        public const string ChatSendPrivate = "chat:send";
        public const string ChatSendGroup = "chat:group:send";
        public const string ChatSubscribe = "chat:subscribe";
        public const string ChatUnsubscribe = "chat:unsubscribe";
        public const string ChatMessageEdit = "chat:message:edit";
        public const string ChatMessageDelete = "chat:message:delete";
        // public const string ChatMessagePurge = "chat:message:purge";
        public const string ChatMessageDeleteAll = "chat:group:delete";
    }
}