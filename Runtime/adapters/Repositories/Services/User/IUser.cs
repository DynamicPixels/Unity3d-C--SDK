using System.Threading.Tasks;
using models.dto;
using models.inputs;
using models.outputs;

namespace adapters.repositories.table.services.user
{
    public interface IUserRepository
    {
        public Task<RowListResponse<User>> Find<T>(T param) where T: FindUserParams;
        public Task<RowResponse<User>> FindUserById<T>(T param) where T: FindUserByIdParams;
        public Task<RowResponse<User>> EditCurrentUser<T>(T param) where T: EditCurrentUserParams;
        public Task<ActionResponse> BanUserById<T>(T param) where T: BanUserByIdParams;

    }
}