using System;
using System.Collections.Generic;

namespace DynamicPixels.GameService.Models
{
    // Enum for Error Codes
    public enum ErrorCode
    {
        // General errors
        InvalidToken,
        UserAlreadyExist,
        UserNotFound,
        InvalidAccessToken,
        PayloadNotValid,
        UserIdNotFoundFromToken,
        TargetUserNotValid,
        CannotRequestYourself,
        RequestAlreadyExist,
        RequestNotFound,
        FriendshipNotFound,
        LeaderboardParticipantsNotUser,
        LeaderboardNotFound,
        LeaderboardParticipantsNotParty,
        PartyNotFound,
        InvalidTeam,
        InvalidChannels,
        MembershipAlreadyExist,
        PermissionDenied,
        MembershipNotFound,
        RowNotFound,
        InvalidSortOrder,
        EmailAlreadyExist,
        PhoneNumberAlreadyExist,
        UsernameAlreadyExist,
        InvalidResponse,
        AchievementNotFound,
        ConnectionNotReady,
        SdkAlreadyInitialized,
        // Add additional specific error codes as needed
        // ...

        // Unknown error (fallback)
        UnknownError
    }

    public class DynamicPixelsException : Exception
    {
        public ErrorCode ErrorCode { get; private set; }

        public DynamicPixelsException(ErrorCode errorCode, string message = null)
            : base(message ?? errorCode.ToString())
        {
            ErrorCode = errorCode;
        }

        public override string ToString()
        {
            return $"Error Code: {ErrorCode}, Message: {Message}";
        }
    }

    public static class ErrorMapper
    {
        private static readonly Dictionary<string, ErrorCode> errorMap = new Dictionary<string, ErrorCode>
{
    { "invalid token", ErrorCode.InvalidToken },
    { "user already exist", ErrorCode.UserAlreadyExist },
    { "user notfound", ErrorCode.UserNotFound },
    { "invalid_access_token", ErrorCode.InvalidAccessToken },
    { "payload is not valid", ErrorCode.PayloadNotValid },
    { "cant find user_id from token", ErrorCode.UserIdNotFoundFromToken },
    { "target user is not valid", ErrorCode.TargetUserNotValid },
    { "cant request to yourself", ErrorCode.CannotRequestYourself },
    { "request already exist", ErrorCode.RequestAlreadyExist },
    { "request notfound", ErrorCode.RequestNotFound },
    { "friendship notfound", ErrorCode.FriendshipNotFound },
    { "leaderboard's participants is not user", ErrorCode.LeaderboardParticipantsNotUser },
    { "leaderboard notfound", ErrorCode.LeaderboardNotFound },
    { "leaderboard's participants is not party", ErrorCode.LeaderboardParticipantsNotParty },
    { "party notfound", ErrorCode.PartyNotFound },
    { "team is not valid", ErrorCode.InvalidTeam },
    { "channels is not valid", ErrorCode.InvalidChannels },
    { "membership is already exist", ErrorCode.MembershipAlreadyExist },
    { "permission denied", ErrorCode.PermissionDenied },
    { "membership notfound", ErrorCode.MembershipNotFound },
    { "row notfound", ErrorCode.RowNotFound },
    { "sort should be asc or desc", ErrorCode.InvalidSortOrder },
    { "email already exist", ErrorCode.EmailAlreadyExist },
    { "phone_number already exist", ErrorCode.PhoneNumberAlreadyExist },
    { "username already exist", ErrorCode.UsernameAlreadyExist },
    { "invalid response", ErrorCode.InvalidResponse },
    { "achievement notfound", ErrorCode.AchievementNotFound },
    { "ConnectionNotReady", ErrorCode.ConnectionNotReady },
    { "SdkAlreadyInitialized", ErrorCode.SdkAlreadyInitialized },
    
    // Add additional mappings as needed
};

        public static ErrorCode GetErrorCode(string errorMessage)
        {
            if (errorMap.TryGetValue(errorMessage, out ErrorCode errorCode))
            {
                return errorCode;
            }

            // Handle unknown error messages
            return ErrorCode.UnknownError; // Add this to your ErrorCode enum
        }
    }
}
