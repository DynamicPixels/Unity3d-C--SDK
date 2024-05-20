using System.Threading.Tasks;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Services.Friendship.Models;

namespace DynamicPixels.GameService.Services.Friendship.Repositories
{
    public interface IFriendshipRepository
    {
        Task<RowListResponse<Models.Friendship>> GetMyFriends<T>(T param) where T : GetMyFriendsParams;
        Task<RowListResponse<Models.Friendship>> GetMyFriendshipRequests<T>(T param) where T : GetMyFriendshipRequestsParams;
        Task<RowResponse<Models.Friendship>> RequestFriendship<T>(T param) where T : RequestFriendshipParams;
        Task<RowResponse<Models.Friendship>> AcceptRequest<T>(T param) where T : AcceptRequestParams;
        Task<RowResponse<Models.Friendship>> RejectRequest<T>(T param) where T : RejectRequestParams;
        Task<ActionResponse> RejectAllRequests<T>(T param) where T : RejectAllRequestsParams;
        Task<ActionResponse> DeleteFriend<T>(T param) where T : DeleteFriendParams;
    }

}