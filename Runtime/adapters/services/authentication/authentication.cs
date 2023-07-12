using System;
using System.Threading.Tasks;
using adapters.repositories.authentication;
using adapters.utils.Logger;
using adapters.utils.WebsocketClient;
using models.dto;
using models.outputs;
using models.inputs;
using ports;
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

        private Task SetupSdk(string token, User user, ConnectionInfo connInfo)
        {
            DynamicPixels.IsAvailable = true;
            DynamicPixels.Token = token;
            DynamicPixels.User = user;
            
            // setup connection
            switch (connInfo?.Protocol)
            {
                case "wss":
                    // DynamicPixels.Agent.Connect(connInfo.Endpoint, token);
                break;       
            }
            
            return Task.CompletedTask;
        }
        
        public async Task<LoginResponse> RegisterWithEmail<T>(T input) where T : RegisterWithEmailParams
        {
            var result = await this._repository.RegisterWithEmail(input);
            await SetupSdk(result.Token, result.User, result.Connection);
            return result;
        }

        public async Task<LoginResponse> LoginWithEmail<T>(T input) where T : LoginWithEmailParams
        {
            var result = await this._repository.LoginWithEmail(input);
            await SetupSdk(result.Token, result.User, result.Connection);
            return result;
        }

        public async Task<LoginResponse> LoginWithGoogle<T>(T input) where T : LoginWithGoogleParams
        {
            var result = await this._repository.LoginWithGoogle(input);
            await SetupSdk(result.Token, result.User, result.Connection);
            return result;
        }

        public async Task<LoginResponse> LoginAsGuest<T>(T input) where T : LoginAsGuestParams
        {
            var result = await this._repository.LoginAsGuest(input);
            await SetupSdk(result.Token, result.User, result.Connection);
            return result;
        }

        public async Task<LoginResponse> LoginWithToken<T>(T input) where T : LoginWithTokenParams
        {
            var result = await this._repository.LoginWithToken(input);
            await SetupSdk(input.Token, new User(), new ConnectionInfo());
            return result;
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
            await SetupSdk(result.Token, result.User, result.Connection);
            return result;
        }

        public Task<bool> IsLoggedIn()
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            DynamicPixels.IsAvailable = false;
            DynamicPixels.Token = string.Empty;
            DynamicPixels.User = null;
            
            // dispose connections
            // DynamicPixels.agent.
        }
    }
}