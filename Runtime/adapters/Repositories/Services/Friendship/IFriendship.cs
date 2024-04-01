using System.Threading.Tasks;
using models.dto;
using models.inputs;
using models.outputs;

namespace adapters.repositories.table.services.friendship
{
    public interface IFriendshipRepository
    {
        Task<RowListResponse<Friendship>> GetMyFriends<T>(T param) where T: GetMyFriendsParams;
        Task<RowListResponse<Friendship>> GetMyFriendshipRequests<T>(T param) where T: GetMyFriendshipRequestsParams;
        Task<RowResponse<Friendship>> RequestFriendship<T>(T param) where T: RequestFriendshipParams;
        Task<RowResponse<Friendship>> AcceptRequest<T>(T param) where T: AcceptRequestParams;
        Task<RowResponse<Friendship>> RejectRequest<T>(T param) where T: RejectRequestParams;
        Task<ActionResponse> RejectAllRequests<T>(T param) where T: RejectAllRequestsParams;
        Task<ActionResponse> DeleteFriend<T>(T param) where T: DeleteFriendParams;
    }

}