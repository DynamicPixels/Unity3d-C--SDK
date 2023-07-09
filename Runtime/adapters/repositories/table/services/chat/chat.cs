using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using adapters.utils.httpClient;
using models;
using models.dto;
using models.inputs;
using models.outputs;
using Newtonsoft.Json;
using ports;

namespace adapters.repositories.table.services
{
    public class ChatRepository : IChatRepository
    {
        public async Task<RowListResponse<Conversation>> GetSubscribedConversations<T>(T input) where T : GetSubscribedConversationsParams
        {
            var response = await WebRequest.Get(UrlMap.GetSubscribedConversationsUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<Conversation>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowListResponse<Message>> GetConversationMessages<T>(T input) where T : GetConversationMessagesParams
        {
            var response = await WebRequest.Get(UrlMap.GetConversationMessagesUrl(input.ConversationId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<Message>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowListResponse<ConversationMember>> GetConversationMembers<T>(T input) where T : GetConversationMembersParams
        {
            var response = await WebRequest.Get(UrlMap.GetConversationMembersUrl(input.ConversationId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<ConversationMember>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }
    }
}