using System.Collections.Generic;
using System.Threading.Tasks;
using GameService.Client.Sdk.Models.inputs;

namespace GameService.Client.Sdk.Services.Services.Friendship
{
    public interface IFriendship
    {
        Task<List<Repositories.Services.Friendship.Friendship>> GetMyFriends<T>(T input) where T : GetMyFriendsParams;
        Task<List<Repositories.Services.Friendship.Friendship>> GetMyFriendshipRequests<T>(T input) where T : GetMyFriendshipRequestsParams;
        Task<Repositories.Services.Friendship.Friendship> RequestFriendship<T>(T input) where T : RequestFriendshipParams;
        Task<Repositories.Services.Friendship.Friendship> AcceptRequest<T>(T input) where T : AcceptRequestParams;
        Task<Repositories.Services.Friendship.Friendship> RejectRequest<T>(T input) where T : RejectRequestParams;
        Task<int> RejectAllRequests<T>(T input) where T : RejectAllRequestsParams;
        Task<bool> DeleteFriend<T>(T input) where T : DeleteFriendParams;
    }
}