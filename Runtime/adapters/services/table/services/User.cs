using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using adapters.repositories.table.services.user;
using models.dto;
using models.inputs;
using models.outputs;
using Newtonsoft.Json;
using ports;
using ports.services;
using ports.utils;
using UnityEngine;

namespace adapters.services.table.services
{
    public class UserService: IUser
    {
        private IUserRepository _repository;
        public UserService()
        {
            this._repository = new UserRepository();
        }

        public async Task<List<User>> Find<T>(T input) where T : FindUserParams
        {
            var result = await this._repository.Find(input);
            return result.List;
        }

        public async Task<User> GetCurrentUser()
        {
            var result = await this._repository.FindUserById(new FindUserByIdParams
            {
                UserId = DynamicPixels.User.Id
            });
            
            return result.Row;
        }

        public async Task<User> FindUserById<T>(T input) where T : FindUserByIdParams
        {
            var result = await this._repository.FindUserById(new FindUserByIdParams
            {
                UserId = input.UserId
            });
           
            return result.Row;
        }

        public async Task<User> EditCurrentUser<T>(T input) where T : EditCurrentUserParams
        {
            Debug.Log(input.Data);
            var result = await this._repository.EditCurrentUser(new EditCurrentUserParams
            {
               Data=input.Data
            });
            Debug.Log(result);
            return result.Row;
        }

        public async Task<bool> BanUserById<T>(T input) where T : BanUserByIdParams
        {
            var result = await this._repository.BanUserById(new BanUserByIdParams
            {
                UserId = input.UserId
            });
           
            return result.Affected > 0;
        }
    }
}