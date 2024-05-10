using System.Threading.Tasks;
using GameService.Client.Sdk.Models.inputs;
using GameService.Client.Sdk.Models.outputs;
using GameService.Client.Sdk.Repositories.Authentication;
using GameService.Client.Sdk.Services.Services.User;

namespace GameService.Client.Sdk.Services.Authentication
{
    public class AuthenticationService : IAuthentication
    {
        private AuthenticationRepository _repository;

        public AuthenticationService()
        {
            _repository = new AuthenticationRepository();
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
                    // connInfo.Endpoint
                    // DynamicPixels.Agent.Connect("wss://ws-europe.dynamicpixels.dev/ws", token);
                    break;
            }

            return Task.CompletedTask;
        }

        public async Task<LoginResponse> RegisterWithEmail<T>(T input) where T : RegisterWithEmailParams
        {
            var result = await _repository.RegisterWithEmail(input);
            await SetupSdk(result.Token, result.User, result.Connection);
            return result;
        }

        public async Task<LoginResponse> LoginWithEmail<T>(T input) where T : LoginWithEmailParams
        {
            var result = await _repository.LoginWithEmail(input);
            await SetupSdk(result.Token, result.User, result.Connection);
            return result;
        }

        public async Task<LoginResponse> LoginWithGoogle<T>(T input) where T : LoginWithGoogleParams
        {
            var result = await _repository.LoginWithGoogle(input);
            await SetupSdk(result.Token, result.User, result.Connection);
            return result;
        }

        public async Task<LoginResponse> LoginAsGuest<T>(T input) where T : LoginAsGuestParams
        {
            var result = await _repository.LoginAsGuest(input);
            await SetupSdk(result.Token, result.User, result.Connection);
            return result;
        }

        public async Task<LoginResponse> LoginWithToken<T>(T input) where T : LoginWithTokenParams
        {
            var result = await _repository.LoginWithToken(input);
            await SetupSdk(input.Token, new User(), new ConnectionInfo());
            return result;
        }

        public async Task<bool> IsOtaReady<T>(T input) where T : IsOtaReadyParams
        {
            var result = await _repository.IsOtaReady(input);
            return result;
        }

        public async Task<bool> SendOtaToken<T>(T input) where T : SendOtaTokenParams
        {
            var result = await _repository.SendOtaToken(input);
            return result.Affected > 0;


        }

        public async Task<LoginResponse> VerifyOtaToken<T>(T input) where T : VerifyOtaTokenParams
        {
            var result = await _repository.VerifyOtaToken(input);
            await SetupSdk(result.Token, result.User, result.Connection);
            return result;


        }

        public bool IsLoggedIn()
        {
            return DynamicPixels.Token != string.Empty;
        }

        public void Logout()
        {
            DynamicPixels.IsAvailable = false;
            DynamicPixels.Token = string.Empty;
            DynamicPixels.User = null;

            // dispose connections
            // TODO: Realtime
            //DynamicPixels.Agent.Disconnect();
        }
    }
}