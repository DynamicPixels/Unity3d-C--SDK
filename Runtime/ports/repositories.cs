using System.Threading.Tasks;
using models.dto;
using models.inputs;
using models.outputs;

namespace ports
{
    public interface ITableRepositories
    {
        public Task<RowListResponse> Aggregation<T>(T input) where T: AggregationInput;
        public Task<RowListResponse> Find<T>(T input) where T: FindInput;
        public Task<RowResponse> FindById<T>(T input) where T: FindByIdInput;
        public Task<RowResponse> FindByIdAndDelete<T>(T input) where T: FindByIdAndDeleteInput;
        public Task<RowResponse> FindByIdAndUpdate<T>(T input) where T: FindByIdAndUpdateInput;
        public Task<RowResponse> Insert<T>(T input) where T: InsertInput;
        public Task<RowResponse> InsertMany<T>(T input) where T: InsertManyInput;
        public Task<ActionResponse> UpdateMany<T>(T input) where T: UpdateManyInput;
        public Task<ActionResponse> Delete<T>(T input) where T: DeleteInput;
        public Task<ActionResponse> DeleteMany<T>(T input) where T: DeleteManyInput;
    }
    
    public interface IAuthenticationRepositories
    {
        Task<LoginResponse> RegisterWithEmail<T>(T input) where T: RegisterWithEmailParams;
        Task<LoginResponse> LoginWithEmail<T>(T input) where T: LoginWithEmailParams;
        Task<LoginResponse> LoginWithGoogle<T>(T input) where T: LoginWithGoogleParams;
        Task<LoginResponse> LoginAsGuest<T>(T input) where T: LoginAsGuestParams;
        Task<bool> IsOtaReady<T>(T input) where T: IsOtaReadyParams;
        Task<OtaResponse> SendOtaToken<T>(T input) where T: SendOtaTokenParams;
        Task<LoginResponse> VerifyOtaToken<T>(T input) where T: VerifyOtaTokenParams;
    }

    public interface IStorageRepositories
    {
        
    }


    public interface ILeaderboardRepository
    {
        Task<RowListResponse<Leaderboard>> GetLeaderBoards<T>(T input) where T: GetLeaderboardsParams;
        Task<RowListResponse<Score>> GetScores<T>(T input) where T: GetScoresParams;
        Task<RowResponse<Score>> GetCurrentUserScore<T>(T input) where T: GetCurrentUserScoreParams;
        Task<RowListResponse<Score>> GetFriendsScores<T>(T input) where T: GetFriendsScoresParams;
        Task<RowResponse<Score>> SubmitScore<T>(T input) where T: SubmitScoreParams;
    }
    
    public interface IAchievementRepository
    {
        Task<RowListResponse<Achievement>> GetAchievements<T>(T input) where T: GetAchievementParams;
        Task<RowListResponse<Unlock>> GetUserAchievements<T>(T input) where T: GetUserAchievementsParams;
        Task<RowResponse<Unlock>> UnlockAchievement<T>(T input) where T: UnlockAchievementParams;
    }
    
    public interface IFriendshipRepository
    {
        Task<RowListResponse<Friendship>> GetMyFriends<T>(T input) where T: GetMyFriendsParams;
        Task<RowListResponse<Friendship>> GetMyFriendshipRequests<T>(T input) where T: GetMyFriendshipRequestsParams;
        Task<RowResponse<Friendship>> RequestFriendship<T>(T input) where T: RequestFriendshipParams;
        Task<RowResponse<Friendship>> AcceptRequest<T>(T input) where T: AcceptRequestParams;
        Task<RowResponse<Friendship>> RejectRequest<T>(T input) where T: RejectRequestParams;
        Task<ActionResponse> RejectAllRequests<T>(T input) where T: RejectAllRequestsParams;
        Task<ActionResponse> DeleteFriend<T>(T input) where T: DeleteFriendParams;
    }
    
    public interface IUserRepository
    {
        public Task<RowListResponse<User>> Find<T>(T input) where T: FindUserParams;
        public Task<RowResponse<User>> FindUserById<T>(T input) where T: FindUserByIdParams;
        public Task<RowResponse<User>> EditUserById<T>(T input) where T: EditUserByIdParams;
        public Task<ActionResponse> BanUserById<T>(T input) where T: BanUserByIdParams;

    }
    
    public interface IDeviceRepository
    {
        Task<RowListResponse<Device>> FindMyDevices<T>(T input) where T: FindMyDeviceParams;
        Task<ActionResponse> RevokeDevice<T>(T input) where T: RevokeDeviceParams;
    }
    
    public interface IChatRepository
    {
        
    }
    
    public interface IPartyRepository
    {
        
    }
}