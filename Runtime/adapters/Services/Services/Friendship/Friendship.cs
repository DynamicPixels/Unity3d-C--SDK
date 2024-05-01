using System.Collections.Generic;
using System.Threading.Tasks;
using GameService.Client.Sdk.Adapters.Repositories.Services.Friendship;
using GameService.Client.Sdk.Models.inputs;

namespace GameService.Client.Sdk.Adapters.Services.Services.Friendship
{
    public class FriendshipService: IFriendship
    {
        private IFriendshipRepository _repository;
        public FriendshipService()
        {
            this._repository = new FriendshipRepository();
        }

        public async Task<List<Repositories.Services.Friendship.Friendship>> GetMyFriends<T>(T input) where T : GetMyFriendsParams
        {
            var result = await this._repository.GetMyFriends(input);
            return result.List;
        }

        public async Task<List<Repositories.Services.Friendship.Friendship>> GetMyFriendshipRequests<T>(T input) where T : GetMyFriendshipRequestsParams
        {
            var result = await this._repository.GetMyFriendshipRequests(input);
            return result.List;
        }

        public async Task<Repositories.Services.Friendship.Friendship> RequestFriendship<T>(T input) where T : RequestFriendshipParams
        {
            var result = await this._repository.RequestFriendship(input);
            return result.Row;
        }

        public async Task<Repositories.Services.Friendship.Friendship> AcceptRequest<T>(T input) where T : AcceptRequestParams
        {
            var result = await this._repository.AcceptRequest(input);
            return result.Row;
        }

        public async Task<Repositories.Services.Friendship.Friendship> RejectRequest<T>(T input) where T : RejectRequestParams
        {
            var result = await this._repository.RejectRequest(input);
            return result.Row;
        }

        public async Task<int> RejectAllRequests<T>(T input) where T : RejectAllRequestsParams
        {
            var result = await this._repository.RejectAllRequests(input);
            return result.Affected;
        }

        public async Task<bool> DeleteFriend<T>(T input) where T : DeleteFriendParams
        {
            var result = await this._repository.DeleteFriend(input);
            return result.Affected > 0;
        }
    }
}