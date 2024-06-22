using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.Chat.Models;
using DynamicPixels.GameService.Services.Chat.Repositories;

namespace DynamicPixels.GameService.Services.Chat
{
    public interface IChat
    {
        public Task Send<T>(T param) where T : SendParams;
        public Task Subscribe<T>(T param) where T : SubscribeParams;
        public Task Unsubscribe<T>(T param) where T : UnsubscribeParams;
        public Task<List<Conversation>> GetSubscribedConversations<T>(T param) where T : GetSubscribedConversationsParams;
        public Task<List<Message>> GetConversationMessages<T>(T param) where T : GetConversationMessagesParams;
        public Task<List<ConversationMember>> GetConversationMembers<T>(T param) where T : GetConversationMembersParams;
        public Task EditMessage<T>(T param) where T : EditMessageParams;
        public Task DeleteMessage<T>(T param) where T : DeleteMessageParams;
        public Task DeleteAllMessage<T>(T param) where T : DeleteAllMessageParams;
    }
}