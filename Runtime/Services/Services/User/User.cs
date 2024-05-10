using System.Collections.Generic;
using System.Threading.Tasks;
using GameService.Client.Sdk.Models.inputs;
using GameService.Client.Sdk.Repositories.Services.User;

namespace GameService.Client.Sdk.Services.Services.User
{
    public class UserService : IUser
    {
        private IUserRepository _repository;
        public UserService()
        {
            _repository = new UserRepository();
        }

        public async Task<List<User>> Find<T>(T input) where T : FindUserParams
        {
            var result = await _repository.Find(input);
            return result.List;
        }

        public async Task<User> GetCurrentUser()
        {
            var result = await _repository.FindUserById(new FindUserByIdParams
            {
                UserId = DynamicPixels.User.Id
            });

            return result.Row;
        }

        public async Task<User> FindUserById<T>(T input) where T : FindUserByIdParams
        {
            var result = await _repository.FindUserById(new FindUserByIdParams
            {
                UserId = input.UserId
            });

            return result.Row;
        }

        public async Task<User> EditCurrentUser<T>(T input) where T : EditCurrentUserParams
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