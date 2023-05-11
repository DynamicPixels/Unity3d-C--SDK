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

        public async Task<RowListResponse> Aggregation<T>(T param) where T : AggregationParams
        {
            var result = await this._repository.Aggregation(param);
            return result;
        }

        public async Task<RowListResponse> Find<T>(T param) where T : FindParams
        {
            var result = await this._repository.Find(param);
            return result;
        }

        public async Task<RowResponse> FindById<T>(T param) where T : FindByIdParams
        {
            var result = await this._repository.FindById(param);
            return result;
        }

        public async Task<RowResponse> FindByIdAndDelete<T>(T param) where T : FindByIdAndDeleteParams
        {
            var result = await this._repository.FindByIdAndDelete(param);
            return result;
        }

        public async Task<RowResponse> FindByIdAndUpdate<T>(T param) where T : FindByIdAndUpdateParams
        {
            var result = await this._repository.FindByIdAndUpdate(param);
            return result;
        }

        public async Task<RowResponse> Insert<T>(T param) where T : InsertParams
        {
            var result = await this._repository.Insert(param);
            return result;
        }

        public async Task<RowResponse> InsertMany<T>(T param) where T : InsertManyParams
        {
            var result = await this._repository.InsertMany(param);
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