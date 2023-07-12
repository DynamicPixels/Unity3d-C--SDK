using System.Collections.Generic;
using System.Threading.Tasks;
using models.dto;
using models.inputs;
using models.outputs;

namespace ports.services
{
    public interface IUser
    {
        Task<List<User>> Find<T>(T input) where T : FindUserParams;
        Task<User> GetCurrentUser();
        Task<User> FindUserById<T>(T input) where T : FindUserByIdParams;
        Task<User> EditCurrentUser<T>(T input) where T : EditCurrentUserParams;
    }
}