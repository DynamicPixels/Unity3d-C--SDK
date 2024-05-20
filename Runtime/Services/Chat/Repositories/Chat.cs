using System.IO;
using System.Threading.Tasks;
using DynamicPixels.GameService.Models;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Services.Chat.Models;
using DynamicPixels.GameService.Utils.HttpClient;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Chat.Repositories
{
    public class ChatRepository : IChatRepository
    {
        public async Task<RowListResponse<Conversation>> GetSubscribedConversations<T>(T input) where T : GetSubscribedConversationsParams
        {
            var response = await WebRequest.Get(UrlMap.GetSubscribedConversationsUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<RowListResponse<Conversation>>(body);
            }
            else
            {
                // Deserialize the error response
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

                // Get the corresponding ErrorCode from the error message
                var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

                // Throw the DynamicPixelsException with the ErrorCode
                throw new DynamicPixelsException(errorCode, errorResponse?.Message);
            }
        }

        public async Task<RowListResponse<Message>> GetConversationMessages<T>(T input) where T : GetConversationMessagesParams
        {
            var response = await WebRequest.Get(UrlMap.GetConversationMessagesUrl(input.ConversationId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<RowListResponse<Message>>(body);
            }
            else
            {
                // Deserialize the error response
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

                // Get the corresponding ErrorCode from the error message
                var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

                // Throw the DynamicPixelsException with the ErrorCode
                throw new DynamicPixelsException(errorCode, errorResponse?.Message);
            }
        }

        public async Task<RowListResponse<ConversationMember>> GetConversationMembers<T>(T input) where T : GetConversationMembersParams
        {
            var response = await WebRequest.Get(UrlMap.GetConversationMembersUrl(input.ConversationId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<RowListResponse<ConversationMember>>(body);
            }
            else
            {
                // Deserialize the error response
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

                // Get the corresponding ErrorCode from the error message
                var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

                // Throw the DynamicPixelsException with the ErrorCode
                throw new DynamicPixelsException(errorCode, errorResponse?.Message);
            }
        }
    }
}