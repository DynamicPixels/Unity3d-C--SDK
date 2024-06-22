namespace DynamicPixels.GameService.Services.Authentication.Repositories
{
    public class UrlMap
    {
        public const string SignupUrl = "/api/auth/email/register";
        public const string SigninUrl = "/api/auth/email/login";
        public const string GoogleAuthUrl = "/api/auth/oauth/google";
        public const string GuestAuthUrl = "/api/auth/guest";
        public const string LoginWithToken = "/api/auth/login";
        public const string IsOtaReadyUrl = "/api/auth/ota";
        public const string SendOtaUrl = "/api/auth/ota";
        public const string VerifyOtaUrl = "/api/auth/ota/verify";
    }
}