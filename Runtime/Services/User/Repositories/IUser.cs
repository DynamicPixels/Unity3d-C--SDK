using System.Threading.Tasks;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Services.User.Models;

namespace DynamicPixels.GameService.Services.User.Repositories
{
    public interface IUserRepository
    {
        public Task<RowListResponse<Models.User>> Find<T>(T param) where T : FindUserParams;
        public Task<RowResponse<Models.User>> FindUserById<T>(T param) where T : FindUserByIdParams;
        public Task<RowResponse<Models.User>> EditCurrentUser<T>(T param) where T : EditCurrentUserParams;
        public Task<ActionResponse> BanUserById<T>(T param) where T : BanUserByIdParams;

    }
}