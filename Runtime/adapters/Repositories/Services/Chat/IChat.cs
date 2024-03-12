using System.Threading.Tasks;
using models.dto;
using models.inputs;
using models.outputs;

namespace adapters.repositories.table.services
{
    public interface IChatRepository
    {
        public Task<RowListResponse<Conversation>> GetSubscribedConversations<T>(T param) where T : GetSubscribedConversationsParams;
        public Task<RowListResponse<Message>> GetConversationMessages<T>(T param) where T : GetConversationMessagesParams;
        public Task<RowListResponse<ConversationMember>> GetConversationMembers<T>(T param) where T : GetConversationMembersParams;

    }

}