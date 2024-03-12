using System.Threading.Tasks;
using models.inputs;
using models.outputs;

namespace adapters.services.authentication
{
    public interface IAuthentication
    {
        Task<LoginResponse> RegisterWithEmail<T>(T input) where T: RegisterWithEmailParams;
        Task<LoginResponse> LoginWithEmail<T>(T input) where T: LoginWithEmailParams;
        Task<LoginResponse> LoginWithGoogle<T>(T input) where T: LoginWithGoogleParams;
        Task<LoginResponse> LoginAsGuest<T>(T input) where T: LoginAsGuestParams;
        Task<LoginResponse> LoginWithToken<T>(T input) where T: LoginWithTokenParams;
        Task<bool> IsOtaReady<T>(T input) where T: IsOtaReadyParams;
        Task<bool> SendOtaToken<T>(T input) where T: SendOtaTokenParams;
        Task<LoginResponse> VerifyOtaToken<T>(T input) where T: VerifyOtaTokenParams;
        bool IsLoggedIn();
        void Logout();
    }
}