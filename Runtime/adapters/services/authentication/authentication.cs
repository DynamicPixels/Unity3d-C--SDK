using System.Threading.Tasks;
using adapters.repositories.authentication;
using models.outputs;
using adapters.repositories.authentication;
using models.inputs;
using ports;
using ports.utils;
using UnityEngine;

namespace adapters.services.authentication
{
    public class AuthenticationService: IAuthentication
    {
        private AuthenticationRepository _repository;

        public AuthenticationService()
        {
            this._repository = new AuthenticationRepository();
        }

        public async Task<LoginResponse> RegisterWithEmail<T>(T input) where T : RegisterWithEmailParams
        {
            var result = await this._repository.RegisterWithEmail(input);
            BlueG.IsAvailable = true;
            BlueG.Token = result.Token;
            BlueG.User = result.User;
            return result;
        }

        public async Task<LoginResponse> LoginWithEmail<T>(T input) where T : LoginWithEmailParams
        {
            var result = await this._repository.LoginWithEmail(input);
            BlueG.IsAvailable = true;
            BlueG.Token = result.Token;
            BlueG.User = result.User;
            return result;
        }

        public async Task<LoginResponse> LoginWithGoogle<T>(T input) where T : LoginWithGoogleParams
        {
            var result = await this._repository.LoginWithGoogle(input);
            BlueG.IsAvailable = true;
            BlueG.Token = result.Token;
            BlueG.User = result.User;
            return result;
        }

        public async Task<LoginResponse> LoginAsGuest<T>(T input) where T : LoginAsGuestParams
        {
            var result = await this._repository.LoginAsGuest(input);
            BlueG.IsAvailable = true;
            BlueG.Token = result.Token;
            BlueG.User = result.User;
            return result;
        }

        public void LoginWithToken<T>(T input) where T : LoginWithTokenParams
        {
            BlueG.IsAvailable = true;
            BlueG.Token = input.Token;
            // load user
        }

        public async Task<bool> IsOtaReady<T>(T input) where T : IsOtaReadyParams
        {
            var result = await this._repository.IsOtaReady(input);
            return result;
        }

        public async Task<bool> SendOtaToken<T>(T input) where T : SendOtaTokenParams
        {
            var result = await this._repository.SendOtaToken(input);
            return result.Status;
        }

        public async Task<LoginResponse> VerifyOtaToken<T>(T input) where T : VerifyOtaTokenParams
        {
            var result = await this._repository.VerifyOtaToken(input);
            BlueG.IsAvailable = true;
            BlueG.Token = result.Token;
            BlueG.User = result.User;
            return result;
        }

        public void Logout()
        {
            BlueG.IsAvailable = false;
            BlueG.Token = string.Empty;
            BlueG.User = null;
        }
    }
}