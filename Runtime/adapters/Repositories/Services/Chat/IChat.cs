using System.Threading.Tasks;
using GameService.Client.Sdk.Models.inputs;
using GameService.Client.Sdk.Models.outputs;

namespace GameService.Client.Sdk.Adapters.Repositories.Services.Chat
{
    public interface IChatRepository
    {
        public Task<RowListResponse<Conversation>> GetSubscribedConversations<T>(T param) where T : GetSubscribedConversationsParams;
        public Task<RowListResponse<Message>> GetConversationMessages<T>(T param) where T : GetConversationMessagesParams;
        public Task<RowListResponse<ConversationMember>> GetConversationMembers<T>(T param) where T : GetConversationMembersParams;

    }

}