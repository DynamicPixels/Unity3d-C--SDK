using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.Friendship.Models;

namespace DynamicPixels.GameService.Services.Friendship
{
    public interface IFriendship
    {
        Task<List<Models.Friendship>> GetMyFriends<T>(T input) where T : GetMyFriendsParams;
        Task<List<Models.Friendship>> GetMyFriendshipRequests<T>(T input) where T : GetMyFriendshipRequestsParams;
        Task<Models.Friendship> RequestFriendship<T>(T input) where T : RequestFriendshipParams;
        Task<Models.Friendship> AcceptRequest<T>(T input) where T : AcceptRequestParams;
        Task<Models.Friendship> RejectRequest<T>(T input) where T : RejectRequestParams;
        Task<int> RejectAllRequests<T>(T input) where T : RejectAllRequestsParams;
        Task<bool> DeleteFriend<T>(T input) where T : DeleteFriendParams;
    }
}