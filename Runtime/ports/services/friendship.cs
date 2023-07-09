using System.Collections.Generic;
using System.Threading.Tasks;
using models.dto;
using models.inputs;

namespace ports.services
{
    public interface IFriendship
    {
        Task<List<Friendship>> GetMyFriends<T>(T input) where T : GetMyFriendsParams;
        Task<List<Friendship>> GetMyFriendshipRequests<T>(T input) where T : GetMyFriendshipRequestsParams;
        Task<Friendship> RequestFriendship<T>(T input) where T : RequestFriendshipParams;
        Task<Friendship> AcceptRequest<T>(T input) where T : AcceptRequestParams;
        Task<Friendship> RejectRequest<T>(T input) where T : RejectRequestParams;
        Task<int> RejectAllRequests<T>(T input) where T : RejectAllRequestsParams;
        Task<bool> DeleteFriend<T>(T input) where T : DeleteFriendParams;
    }
}