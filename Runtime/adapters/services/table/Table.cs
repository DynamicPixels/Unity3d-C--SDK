using System.Threading.Tasks;
using adapters.repositories.table;
using models.outputs;
using adapters.services.table.services;
using models.inputs;
using ports;
using ports.services;
using ports.utils;

namespace adapters.services.table
{
    public class TableService: ITable
    {
        private TableRepository _repository;
        private DynamicPixelsServices _services; 
            
        public static IAchievement Achievement;
        public static ILeaderboard Leaderboard;
        public static IChat Chat;
        public static IDevice Device;
        public static IUser User;
        public static IFriendship Friendship;
        public static IParty Party;

        public TableService(ISocketAgent agent)
        {
            _repository = new TableRepository();
            _services = new DynamicPixelsServices(agent);
            
            Achievement = new AchievementService();
            Leaderboard = new LeaderboardService();
            Device = new DeviceService();
            User = new UserService();
            Friendship = new FriendshipService();
            Party = new PartyService();
            Chat = new ChatService(agent);
        }

        public DynamicPixelsServices GetServices()
        {
            return _services;
        }

        public async Task<RowListResponse<TY>> Aggregation<TY, T>(T param) where T : AggregationParams
        {
            var result = await this._repository.Aggregation<TY, T>(param);
            return result;
        }

        public async Task<RowListResponse<TY>> Find<TY, T>(T param) where T : FindParams
        {
            var result = await this._repository.Find<TY, T>(param);
            return result;
        }

        public async Task<RowResponse<TY>> FindById<TY, T>(T param) where T : FindByIdParams
        {
            var result = await this._repository.FindById<TY, T>(param);
            return result;
        }

        public async Task<RowResponse<TY>> FindByIdAndDelete<TY, T>(T param) where T : FindByIdAndDeleteParams
        {
            var result = await this._repository.FindByIdAndDelete<TY, T>(param);
            return result;
        }

        public async Task<RowResponse<TY>> FindByIdAndUpdate<TY, T>(T param) where T : FindByIdAndUpdateParams
        {
            var result = await this._repository.FindByIdAndUpdate<TY, T>(param);
            return result;
        }

        public async Task<RowResponse<TY>> Insert<TY, T>(T param) where T : InsertParams
        {
            var result = await this._repository.Insert<TY, T>(param);
            return result;
        }

        public async Task<RowResponse<TY>> InsertMany<TY, T>(T param) where T : InsertManyParams
        {
            var result = await this._repository.InsertMany<TY, T>(param);
            return result;
        }

        public async Task<ActionResponse> UpdateMany<T>(T param) where T : UpdateManyParams
        {
            var result = await this._repository.UpdateMany(param);
            return result;
        }

        public async Task<ActionResponse> Delete<T>(T param) where T : DeleteParams
        {
            var result = await this._repository.Delete(param);
            return result;
        }

        public async Task<ActionResponse> DeleteMany<T>(T param) where T : DeleteManyParams
        {
            var result = await this._repository.DeleteMany(param);
            return result;
        }
    }
}