using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.User.Models;
using DynamicPixels.GameService.Services.User.Repositories;

namespace DynamicPixels.GameService.Services.User
{
    public class UserService : IUser
    {
        private IUserRepository _repository;
        public UserService()
        {
            _repository = new UserRepository();
        }

        public async Task<List<Models.User>> Find<T>(T input) where T : FindUserParams
        {
            var result = await _repository.Find(input);
            return result.List;
        }

        public async Task<Models.User> GetCurrentUser()
        {
            var result = await _repository.FindUserById(new FindUserByIdParams
            {
                UserId = ServiceHub.User.Id
            });

            return result.Row;
        }

        public async Task<Models.User> FindUserById<T>(T input) where T : FindUserByIdParams
        {
            var result = await _repository.FindUserById(new FindUserByIdParams
            {
                UserId = input.UserId
            });

            return result.Row;
        }

        public async Task<Models.User> EditCurrentUser<T>(T input) where T : EditCurrentUserParams
        {
            var result = await _repository.EditCurrentUser(new EditCurrentUserParams
            {
                Data = input.Data
            });

            return result.Row;
        }

        public async Task<bool> BanUserById<T>(T input) where T : BanUserByIdParams
        {
            var result = await _repository.BanUserById(new BanUserByIdParams
            {
                UserId = input.UserId
            });

            return result.Affected > 0;
        }
    }
}