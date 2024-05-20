using System.Threading.Tasks;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Services.Authentication.Models;

namespace DynamicPixels.GameService.Services.Authentication.Repositories
{
    public interface IAuthenticationRepositories
    {
        Task<LoginResponse> RegisterWithEmail<T>(T param) where T : RegisterWithEmailParams;
        Task<LoginResponse> LoginWithEmail<T>(T param) where T : LoginWithEmailParams;
        Task<LoginResponse> LoginWithGoogle<T>(T param) where T : LoginWithGoogleParams;
        Task<LoginResponse> LoginAsGuest<T>(T param) where T : LoginAsGuestParams;
        Task<bool> IsOtaReady<T>(T param) where T : IsOtaReadyParams;
        Task<ActionResponse> SendOtaToken<T>(T param) where T : SendOtaTokenParams;
        Task<LoginResponse> VerifyOtaToken<T>(T param) where T : VerifyOtaTokenParams;
    }
}