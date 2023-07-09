using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using adapters.repositories.authentication;
using models.outputs;
using adapters.utils.httpClient;
using models;
using models.inputs;
using Newtonsoft.Json;
using ports;
using UnityEngine;

namespace adapters.repositories.authentication
{
    public class AuthenticationRepository :IAuthenticationRepositories
    {

        public AuthenticationRepository()
        {
        }

        public async Task<LoginResponse> RegisterWithEmail<T>(T input) where T : RegisterWithEmailParams
        {
            var response = await WebRequest.Post(urlMap.SignupUrl, input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<LoginResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }

        public async Task<LoginResponse> LoginWithEmail<T>(T input) where T : LoginWithEmailParams
        {
            var response = await WebRequest.Post(urlMap.SigninUrl, input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<LoginResponse>(body);

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body)?.Message);
        }

        public async Task<LoginResponse> LoginWithToken<T>(T input) where T : LoginWithTokenParams
        {
            var response = await WebRequest.Post(urlMap.LoginWithToken, input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<LoginResponse>(body);

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body)?.Message);
        }

        public async Task<LoginResponse> LoginWithGoogle<T>(T input) where T : LoginWithGoogleParams
        {
            var response = await WebRequest.Post(urlMap.GoogleAuthUrl, input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<LoginResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);

        }

        public async Task<LoginResponse> LoginAsGuest<T>(T input) where T : LoginAsGuestParams
        {
            var response = await WebRequest.Post(urlMap.GuestAuthUrl, input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<LoginResponse>(body);

            Debug.Log(body);
            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body)?.Message);
        }

        public async Task<bool> IsOtaReady<T>(T input) where T : IsOtaReadyParams
        {
            var response = await WebRequest.Post(urlMap.IsOtaReadyUrl, input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<bool>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);

        }

        public async Task<OtaResponse> SendOtaToken<T>(T input) where T : SendOtaTokenParams
        {
            var response = await WebRequest.Post(urlMap.SendOtaUrl, input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<OtaResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);

        }

        public async Task<LoginResponse> VerifyOtaToken<T>(T input) where T : VerifyOtaTokenParams
        {
            var response = await WebRequest.Post(urlMap.VerifyOtaUrl, input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<LoginResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync())?.Message);
        }
    }
}