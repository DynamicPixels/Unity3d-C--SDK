using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.Friendship.Models;
using DynamicPixels.GameService.Services.Friendship.Repositories;

namespace DynamicPixels.GameService.Services.Friendship
{
    public class FriendshipService : IFriendship
    {
        private IFriendshipRepository _repository;
        public FriendshipService()
        {
            _repository = new FriendshipRepository();
        }

        public async Task<List<Models.Friendship>> GetMyFriends<T>(T input) where T : GetMyFriendsParams
        {
            var result = await _repository.GetMyFriends(input);
            return result.List;
        }

        public async Task<List<Models.Friendship>> GetMyFriendshipRequests<T>(T input) where T : GetMyFriendshipRequestsParams
        {
            var result = await _repository.GetMyFriendshipRequests(input);
            return result.List;
        }

        public async Task<Models.Friendship> RequestFriendship<T>(T input) where T : RequestFriendshipParams
        {
            var result = await _repository.RequestFriendship(input);
            return result.Row;
        }

        public async Task<Models.Friendship> AcceptRequest<T>(T input) where T : AcceptRequestParams
        {
            var result = await _repository.AcceptRequest(input);
            return result.Row;
        }

        public async Task<Models.Friendship> RejectRequest<T>(T input) where T : RejectRequestParams
        {
            var result = await _repository.RejectRequest(input);
            return result.Row;
        }

        public async Task<int> RejectAllRequests<T>(T input) where T : RejectAllRequestsParams
        {
            var result = await _repository.RejectAllRequests(input);
            return result.Affected;
        }

        public async Task<bool> DeleteFriend<T>(T input) where T : DeleteFriendParams
        {
            var result = await _repository.DeleteFriend(input);
            return result.Affected > 0;
        }
    }
}