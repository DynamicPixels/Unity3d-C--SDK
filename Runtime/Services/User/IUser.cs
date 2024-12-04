using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.User.Models;

namespace DynamicPixels.GameService.Services.User
{
    public interface IUser
    {
        Task<List<Models.User>> Find<T>(T input) where T : FindUserParams;
        Task<Models.User> GetCurrentUser();
        Task<Models.User> FindUserById<T>(T input) where T : FindUserByIdParams;
        Task<Models.User> EditCurrentUser<T>(T input) where T : EditCurrentUserParams;
    }
}