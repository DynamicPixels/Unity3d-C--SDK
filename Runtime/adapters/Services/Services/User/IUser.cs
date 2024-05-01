using System.Collections.Generic;
using System.Threading.Tasks;
using GameService.Client.Sdk.Models.inputs;

namespace GameService.Client.Sdk.Adapters.Services.Services.User
{
    public interface IUser
    {
        Task<List<User>> Find<T>(T input) where T : FindUserParams;
        Task<User> GetCurrentUser();
        Task<User> FindUserById<T>(T input) where T : FindUserByIdParams;
        Task<User> EditCurrentUser<T>(T input) where T : EditCurrentUserParams;
    }
}