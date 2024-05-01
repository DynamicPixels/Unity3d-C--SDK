using System.IO;
using System.Threading.Tasks;
using GameService.Client.Sdk.Adapters.Utils.HttpClient;
using GameService.Client.Sdk.Models;
using GameService.Client.Sdk.Models.inputs;
using GameService.Client.Sdk.Models.outputs;
using Newtonsoft.Json;

namespace GameService.Client.Sdk.Adapters.Repositories.Services.User
{
    public class UserRepository : IUserRepository
    {
        public async Task<RowListResponse<Adapters.Services.Services.User.User>> Find<T>(T input) where T : FindUserParams
        {
            var response = await WebRequest.Post(UrlMap.FindUsersUrl, input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<RowListResponse<Adapters.Services.Services.User.User>>(body);
            }
            else
            {
                // Deserialize the error response
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

                // Get the corresponding ErrorCode from the error message
                var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

                // Throw the DynamicPixelsException with the ErrorCode
                throw new DynamicPixelsException(errorCode, errorResponse?.Message);
            }
        }

        public async Task<RowResponse<Adapters.Services.Services.User.User>> FindUserById<T>(T input) where T : FindUserByIdParams
        {
            var response = await WebRequest.Get(UrlMap.FindUserByIdUrl(input.UserId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<RowResponse<Adapters.Services.Services.User.User>>(body);
            }
            else
            {
                // Deserialize the error response
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

                // Get the corresponding ErrorCode from the error message
                var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

                // Throw the DynamicPixelsException with the ErrorCode
                throw new DynamicPixelsException(errorCode, errorResponse?.Message);
            }
        }

        public async Task<RowResponse<Adapters.Services.Services.User.User>> EditCurrentUser<T>(T input) where T : EditCurrentUserParams
        {
            var response = await WebRequest.Put(UrlMap.EditCurrentUserUrl, input.ToString());

            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<RowResponse<Adapters.Services.Services.User.User>>(body);
            }
            else
            {
                // Deserialize the error response
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

                // Get the corresponding ErrorCode from the error message
                var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

                // Throw the DynamicPixelsException with the ErrorCode
                throw new DynamicPixelsException(errorCode, errorResponse?.Message);
            }
        }

        public async Task<ActionResponse> BanUserById<T>(T input) where T : BanUserByIdParams
        {
            var response = await WebRequest.Delete(UrlMap.BanUserByIdUrl(input.UserId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ActionResponse>(body);
            }
            else
            {
                // Deserialize the error response
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

                // Get the corresponding ErrorCode from the error message
                var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

                // Throw the DynamicPixelsException with the ErrorCode
                throw new DynamicPixelsException(errorCode, errorResponse?.Message);
            }
        }
    }
}