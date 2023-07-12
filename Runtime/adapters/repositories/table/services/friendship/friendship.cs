
using System.IO;
using System.Threading.Tasks;
using adapters.utils.httpClient;
using models;
using models.dto;
using models.inputs;
using models.outputs;
using Newtonsoft.Json;
using ports;
using ports.utils;
using UnityEngine;

namespace adapters.repositories.table.services.friendship
{
    public class FriendshipRepository:IFriendshipRepository
    {
        
        public async Task<RowListResponse<Friendship>> GetMyFriends<T>(T input) where T : GetMyFriendsParams
        {
            var response = await WebRequest.Get(UrlMap.GetMyFriendsUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<Friendship>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);

        }

        public async Task<RowListResponse<Friendship>> GetMyFriendshipRequests<T>(T input) where T : GetMyFriendshipRequestsParams
        {
            var response = await WebRequest.Get(UrlMap.GetMyFriendshipRequestsUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<Friendship>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowResponse<Friendship>> RequestFriendship<T>(T input) where T : RequestFriendshipParams
        {
            var response = await WebRequest.Post(UrlMap.RequestFriendshipUrl, input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<Friendship>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowResponse<Friendship>> AcceptRequest<T>(T input) where T : AcceptRequestParams
        {
            var response = await WebRequest.Post(UrlMap.AcceptRequestUrl(input.RequestId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<Friendship>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowResponse<Friendship>> RejectRequest<T>(T input) where T : RejectRequestParams
        {
            var response = await WebRequest.Delete(UrlMap.RejectRequestUrl(input.RequestId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<Friendship>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<ActionResponse> RejectAllRequests<T>(T input) where T : RejectAllRequestsParams
        {
            var response = await WebRequest.Delete(UrlMap.RejectAllRequestsUrl);
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ActionResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<ActionResponse> DeleteFriend<T>(T input) where T : DeleteFriendParams
        {
            var response = await WebRequest.Delete(UrlMap.DeleteFriendUrl(input.UserId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ActionResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }
    }
}