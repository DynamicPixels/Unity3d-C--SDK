using System.Threading.Tasks;
using GameService.Client.Sdk.Models.inputs;
using GameService.Client.Sdk.Models.outputs;

namespace GameService.Client.Sdk.Repositories.Services.User
{
    public interface IUserRepository
    {
        public Task<RowListResponse<Sdk.Services.Services.User.User>> Find<T>(T param) where T : FindUserParams;
        public Task<RowResponse<Sdk.Services.Services.User.User>> FindUserById<T>(T param) where T : FindUserByIdParams;
        public Task<RowResponse<Sdk.Services.Services.User.User>> EditCurrentUser<T>(T param) where T : EditCurrentUserParams;
        public Task<ActionResponse> BanUserById<T>(T param) where T : BanUserByIdParams;

    }
}