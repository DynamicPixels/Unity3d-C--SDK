using System.Collections.Generic;
using System.Threading.Tasks;
using models.dto;
using models.inputs;
using models.outputs;
using System;
namespace ports
{
    public interface ISynchroniseRepositories
    {
        public Task<DateTime> GetServerTime();
    }
    public interface ITableRepositories
    {
        public Task<RowListResponse<TY>> Aggregation<TY, T>(T Params) where T: AggregationParams;
        public Task<RowListResponse<TY>> Find<TY, T>(T Params) where T: FindParams;
        public Task<RowResponse<TY>> FindById<TY, T>(T Params) where T: FindByIdParams;
        public Task<RowResponse<TY>> FindByIdAndDelete<TY, T>(T Params) where T: FindByIdAndDeleteParams;
        public Task<RowResponse<TY>> FindByIdAndUpdate<TY, T>(T Params) where T: FindByIdAndUpdateParams;
        public Task<RowResponse<TY>> Insert<TY, T>(T Params) where T: InsertParams;
        public Task<RowResponse<TY>> InsertMany<TY, T>(T Params) where T: InsertManyParams;
        public Task<ActionResponse> UpdateMany<T>(T Params) where T: UpdateManyParams;
        public Task<ActionResponse> Delete<T>(T Params) where T: DeleteParams;
        public Task<ActionResponse> DeleteMany<T>(T Params) where T: DeleteManyParams;
    }
    
    public interface IAuthenticationRepositories
    {
        Task<LoginResponse> RegisterWithEmail<T>(T Params) where T: RegisterWithEmailParams;
        Task<LoginResponse> LoginWithEmail<T>(T Params) where T: LoginWithEmailParams;
        Task<LoginResponse> LoginWithGoogle<T>(T Params) where T: LoginWithGoogleParams;
        Task<LoginResponse> LoginAsGuest<T>(T Params) where T: LoginAsGuestParams;
        Task<bool> IsOtaReady<T>(T Params) where T: IsOtaReadyParams;
        Task<ActionResponse> SendOtaToken<T>(T Params) where T: SendOtaTokenParams;
        Task<LoginResponse> VerifyOtaToken<T>(T Params) where T: VerifyOtaTokenParams;
    }

    public interface IStorageRepositories
    {
        Task<FileMetadata> GetFileInfo(string fileName);
        Task Download(string fileName);
    }


    public interface ILeaderboardRepository
    {
        Task<RowListResponse<Leaderboard>> GetLeaderBoards<T>(T Params) where T : GetLeaderboardsParams;
        Task<RowListResponse<TOutput>> GetUsersScores<TInput, TOutput>(TInput input)
            where TInput : GetScoresParams
            where TOutput : UserScore;
        Task<RowListResponse<TOutput>> GetPartiesScores<TInput, TOutput>(TInput input)
            where TInput : GetScoresParams
            where TOutput : UserScore;
        Task<RowResponse<TOutput>> GetCurrentUserScore<TInput, TOutput>(TInput input)
           where TInput : GetCurrentUserScoreParams
           where TOutput : UserScore;
        Task<RowListResponse<UserScore>> GetFriendsScores<T>(T Params) where T : GetFriendsScoresParams;
        Task<RowResponse<TOutput>> SubmitScore<TInput, TOutput>(TInput input)
           where TInput : SubmitScoreParams
           where TOutput : UserScore;

    }
    public interface IAchievementRepository
    {
        Task<RowListResponse<RichAchievement>> GetAchievements<T>(T Params) where T: GetAchievementParams;
        Task<RowResponse<Unlock>> UnlockAchievement<T>(T Params) where T: UnlockAchievementParams;
    }
    
    public interface IFriendshipRepository
    {
        Task<RowListResponse<Friendship>> GetMyFriends<T>(T Params) where T: GetMyFriendsParams;
        Task<RowListResponse<Friendship>> GetMyFriendshipRequests<T>(T Params) where T: GetMyFriendshipRequestsParams;
        Task<RowResponse<Friendship>> RequestFriendship<T>(T Params) where T: RequestFriendshipParams;
        Task<RowResponse<Friendship>> AcceptRequest<T>(T Params) where T: AcceptRequestParams;
        Task<RowResponse<Friendship>> RejectRequest<T>(T Params) where T: RejectRequestParams;
        Task<ActionResponse> RejectAllRequests<T>(T Params) where T: RejectAllRequestsParams;
        Task<ActionResponse> DeleteFriend<T>(T Params) where T: DeleteFriendParams;
    }
    
    public interface IUserRepository
    {
        public Task<RowListResponse<User>> Find<T>(T Params) where T: FindUserParams;
        public Task<RowResponse<User>> FindUserById<T>(T Params) where T: FindUserByIdParams;
        public Task<RowResponse<User>> EditCurrentUser<T>(T Params) where T: EditCurrentUserParams;
        public Task<ActionResponse> BanUserById<T>(T Params) where T: BanUserByIdParams;

    }
    
    public interface IDeviceRepository
    {
        Task<RowListResponse<Device>> FindMyDevices<T>(T Params) where T: FindMyDeviceParams;
        Task<ActionResponse> RevokeDevice<T>(T Params) where T: RevokeDeviceParams;
    }
    
    public interface IChatRepository
    {
        public Task<RowListResponse<Conversation>> GetSubscribedConversations<T>(T Params) where T : GetSubscribedConversationsParams;
        public Task<RowListResponse<Message>> GetConversationMessages<T>(T Params) where T : GetConversationMessagesParams;
        public Task<RowListResponse<ConversationMember>> GetConversationMembers<T>(T Params) where T : GetConversationMembersParams;

    }
    
    public interface IPartyRepository
    {
        Task<RowListResponse<Party>> GetParties<T>(T Params) where T: GetPartiesParams;
        Task<RowResponse<Party>> CreateParty<T>(T Params) where T: CreatePartyParams;
        Task<RowListResponse<Party>> GetSubscribedParties<T>(T Params) where T: GetSubscribedPartiesParams;
        Task<RowResponse<Party>> GetPartyById<T>(T Params) where T: GetPartyByIdParams;
        Task<RowResponse<PartyMember>> JoinToParty<T>(T Params) where T: JoinToPartyParams;
        Task<RowResponse<Party>> EditParty<T>(T Params) where T: EditPartyParams;
        Task<ActionResponse> LeaveParty<T>(T Params) where T: LeavePartyParams;
        Task<RowListResponse<RichPartyMember>> GetPartyMembers<T>(T Params) where T: GetPartyMembersParams;
        Task<RowListResponse<PartyMember>> GetPartyWaitingMembers<T>(T Params) where T: GetPartyWaitingMembersParams;
        Task<RowResponse<PartyMember>> AcceptJoining<T>(T Params) where T: AcceptJoiningParams;
        Task<RowResponse<PartyMember>> RejectJoining<T>(T Params) where T: RejectJoiningParams;

    }
}