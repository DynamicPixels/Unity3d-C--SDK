using System.Threading.Tasks;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Services.Authentication.Models;
using DynamicPixels.GameService.Utils.HttpClient;

namespace DynamicPixels.GameService.Services.Authentication.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepositories
    {

        public AuthenticationRepository()
        {
        }

        public Task<LoginResponse> RegisterWithEmail<T>(T input) where T : RegisterWithEmailParams
        {
            return WebRequest.Post< LoginResponse>(UrlMap.SignupUrl, input.ToString());
        }

        public Task<LoginResponse> LoginWithEmail<T>(T input) where T : LoginWithEmailParams
        {
            return WebRequest.Post< LoginResponse>(UrlMap.SigninUrl, input.ToString());
        }

        public Task<LoginResponse> LoginWithToken<T>(T input) where T : LoginWithTokenParams
        {
            return WebRequest.Post<LoginResponse>(UrlMap.LoginWithToken, input.ToString());
        }

        public Task<LoginResponse> LoginWithGoogle<T>(T input) where T : LoginWithGoogleParams
        {
            return WebRequest.Post<LoginResponse>(UrlMap.GoogleAuthUrl, input.ToString());
        }

        public Task<LoginResponse> LoginAsGuest<T>(T input) where T : LoginAsGuestParams
        {
            return WebRequest.Post<LoginResponse>(UrlMap.GuestAuthUrl, input.ToString());
        }

        public Task<bool> IsOtaReady<T>(T input) where T : IsOtaReadyParams
        {
            return WebRequest.Post<bool>(UrlMap.IsOtaReadyUrl, input.ToString());
        }

        public Task<ActionResponse> SendOtaToken<T>(T input) where T : SendOtaTokenParams
        {
            return WebRequest.Post<ActionResponse>(UrlMap.SendOtaUrl, input.ToString());
        }

        public Task<LoginResponse> VerifyOtaToken<T>(T input) where T : VerifyOtaTokenParams
        {
            return WebRequest.Post<LoginResponse>(UrlMap.VerifyOtaUrl, input.ToString());
        }
    }
}