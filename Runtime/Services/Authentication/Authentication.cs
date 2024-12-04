using System.Threading.Tasks;
using DynamicPixels.GameService.Services.Authentication.Models;
using DynamicPixels.GameService.Services.Authentication.Repositories;

namespace DynamicPixels.GameService.Services.Authentication
{
    /// <summary>
    /// Provides authentication services for user registration, login, and session management.
    /// </summary>
    public class AuthenticationService : IAuthentication
    {
        private AuthenticationRepository _repository;
        public AuthenticationService()
        {
            _repository = new AuthenticationRepository();
        }

        /// <summary>
        /// Configures the SDK with user session details.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <param name="user">The authenticated user details.</param>
        /// <param name="connInfo">The connection information for establishing a session.</param>
        /// <returns>A task representing the completion of the setup process.</returns>
        private Task SetupSdk(string token, User.Models.User user, ConnectionInfo connInfo)
        {
            ServiceHub.IsAvailable = true;
            ServiceHub.Token = token;
            ServiceHub.User = user;

            // Setup connection based on protocol
            switch (connInfo?.Protocol)
            {
                case "wss":
                    ServiceHub.Agent.ConnectAsync(token);
                    break;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Registers a new user with an email address.
        /// </summary>
        /// <typeparam name="T">The type of the input parameters.</typeparam>
        /// <param name="input">The registration parameters.</param>
        /// <returns>A task representing the registration process, with a result containing the login response.</returns>
        public async Task<LoginResponse> RegisterWithEmail<T>(T input) where T : RegisterWithEmailParams
        {
            var result = await _repository.RegisterWithEmail(input);
            await SetupSdk(result.Token, result.User, result.Connection);
            return result;
        }

        /// <summary>
        /// Logs in a user with an email address.
        /// </summary>
        /// <typeparam name="T">The type of the input parameters.</typeparam>
        /// <param name="input">The login parameters.</param>
        /// <returns>A task representing the login process, with a result containing the login response.</returns>
        public async Task<LoginResponse> LoginWithEmail<T>(T input) where T : LoginWithEmailParams
        {
            var result = await _repository.LoginWithEmail(input);
            await SetupSdk(result.Token, result.User, result.Connection);
            return result;
        }

        /// <summary>
        /// Logs in a user with a Google account.
        /// </summary>
        /// <typeparam name="T">The type of the input parameters.</typeparam>
        /// <param name="input">The Google login parameters.</param>
        /// <returns>A task representing the login process, with a result containing the login response.</returns>
        public async Task<LoginResponse> LoginWithGoogle<T>(T input) where T : LoginWithGoogleParams
        {
            var result = await _repository.LoginWithGoogle(input);
            await SetupSdk(result.Token, result.User, result.Connection);
            return result;
        }

        /// <summary>
        /// Logs in a user as a guest.
        /// </summary>
        /// <typeparam name="T">The type of the input parameters.</typeparam>
        /// <param name="input">The guest login parameters.</param>
        /// <returns>A task representing the login process, with a result containing the login response.</returns>
        public async Task<LoginResponse> LoginAsGuest<T>(T input) where T : LoginAsGuestParams
        {
            var result = await _repository.LoginAsGuest(input);
            await SetupSdk(result.Token, result.User, result.Connection);
            return result;
        }

        /// <summary>
        /// Logs in a user using an authentication token.
        /// </summary>
        /// <typeparam name="T">The type of the input parameters.</typeparam>
        /// <param name="input">The token login parameters.</param>
        /// <returns>A task representing the login process, with a result containing the login response.</returns>
        public async Task<LoginResponse> LoginWithToken<T>(T input) where T : LoginWithTokenParams
        {
            var result = await _repository.LoginWithToken(input);
            await SetupSdk(input.Token, new User.Models.User(), new ConnectionInfo());
            return result;
        }

        /// <summary>
        /// Checks if One-Time Authentication (OTA) is ready.
        /// </summary>
        /// <typeparam name="T">The type of the input parameters.</typeparam>
        /// <param name="input">The OTA readiness parameters.</param>
        /// <returns>A task representing the readiness check, with a result indicating if OTA is ready.</returns>
        public async Task<bool> IsOtaReady<T>(T input) where T : IsOtaReadyParams
        {
            var result = await _repository.IsOtaReady(input);
            return result;
        }

        /// <summary>
        /// Sends a One-Time Authentication (OTA) token to the user.
        /// </summary>
        /// <typeparam name="T">The type of the input parameters.</typeparam>
        /// <param name="input">The parameters for sending the OTA token.</param>
        /// <returns>
        /// A task representing the process, with a result indicating if the token was successfully sent.
        /// </returns>
        public async Task<bool> SendOtaToken<T>(T input) where T : SendOtaTokenParams
        {
            var result = await _repository.SendOtaToken(input);
            return result.Affected > 0;
        }

        /// <summary>
        /// Verifies the One-Time Authentication (OTA) token.
        /// </summary>
        /// <typeparam name="T">The type of the input parameters.</typeparam>
        /// <param name="input">The parameters for verifying the OTA token.</param>
        /// <returns>A task representing the verification process, with a result containing the login response.</returns>
        public async Task<LoginResponse> VerifyOtaToken<T>(T input) where T : VerifyOtaTokenParams
        {
            var result = await _repository.VerifyOtaToken(input);
            await SetupSdk(result.Token, result.User, result.Connection);
            return result;
        }

        /// <summary>
        /// Checks if the user is currently logged in.
        /// </summary>
        /// <returns>True if the user is logged in; otherwise, false.</returns>
        public bool IsLoggedIn()
        {
            return ServiceHub.Token != string.Empty;
        }

        /// <summary>
        /// Logs out the current user and clears session data.
        /// </summary>
        public void Logout()
        {
            ServiceHub.IsAvailable = false;
            ServiceHub.Token = string.Empty;
            ServiceHub.User = null;

            // Dispose connections (if applicable).
            // TODO: Realtime support for disconnecting agents.
            // DynamicPixels.Agent.Disconnect();
        }
    }
}
