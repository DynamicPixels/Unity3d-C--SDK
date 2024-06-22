using DynamicPixels.GameService.Services.Chat.Repositories;

namespace DynamicPixels.GameService.Services.Chat.Models
{
    public enum ConversationType 
    {
        Private,
        Group
    }

    public class SendParams
    {
        public ConversationType Type { get; set; }
        public int TargetUserId { get; set; }
        public Message Message { get; set; }
    }

    public class SubscribeParams
    {
        public int ConversationId { get; set; }
        public string ConversationName { get; set; }
    }

    public class UnsubscribeParams
    {
        public int ConversationId { get; set; }
    }

    public class GetSubscribedConversationsParams
    {
        public int Skip { get; set; }
        public int Limit { get; set; }
    }

    public class GetConversationMessagesParams
    {
        public int ConversationId { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }

    public class GetConversationMembersParams
    {
        public int ConversationId { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }

    public class EditMessageParams
    {
        public int ConversationId { get; set; }
        public int MessageId { get; set; }
        public Message Message { get; set; }
    }

    public class DeleteMessageParams
    {
        public int ConversationId { get; set; }
        public int MessageId { get; set; }
    }

    public class DeleteAllMessageParams
    {
        public int ConversationId { get; set; }
        public int TargetUserId { get; set; }
    }
}