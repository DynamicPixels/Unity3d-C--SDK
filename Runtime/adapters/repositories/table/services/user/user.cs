using System;
using System.IO;
using System.Threading.Tasks;
using adapters.utils.httpClient;
using models;
using models.dto;
using models.inputs;
using models.outputs;
using Newtonsoft.Json;
using ports;
using ports.utils;
using UnityEngine;

namespace adapters.repositories.table.services.user
{
    public class UserRepository:IUserRepository
    {
        public async Task<RowListResponse<User>> Find<T>(T input) where T : FindUserParams
        {
            var response = await WebRequest.Post(UrlMap.FindUsersUrl, input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<User>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowResponse<User>> FindUserById<T>(T input) where T : FindUserByIdParams
        {
            var response = await WebRequest.Get(UrlMap.FindUserByIdUrl(input.UserId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<User>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<RowResponse<User>> EditCurrentUser<T>(T input) where T : EditCurrentUserParams
        {
            var response = await WebRequest.Put(UrlMap.EditCurrentUserUrl, input.ToString());
            Debug.Log(input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            Debug.Log(body);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<User>>(body);

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<ActionResponse> BanUserById<T>(T input) where T : BanUserByIdParams
        {
            var response = await WebRequest.Delete(UrlMap.BanUserByIdUrl(input.UserId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ActionResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }
    }
}