using System.Threading.Tasks;
using adapters.repositories.table;
using models.inputs;
using models.outputs;
using adapters.repositories.table;
using adapters.services.table.services;
using ports;
using ports.services;
using ports.utils;

namespace adapters.services.table
{
    public class TableService: ITable
    {
        private TableRepository _repository;
        
        public static IAchievement Achievement;
        public static ILeaderboard Leaderboard;
        public static IChat Chat;
        public static IDevice Device;
        public static IUser User;
        public static IFriendship Friendship;
        public static IParty Party;

        public TableService()
        {
            this._repository = new TableRepository();
            
            Achievement = new AchievementService();
            Leaderboard = new LeaderboardService();
            Chat = new ChatService();
            Device = new DeviceService();
            User = new UserService();
            Friendship = new FriendshipService();
            Party = new PartyService();
        }


        public BlueGServices GetServices()
        {
            throw new System.NotImplementedException();
        }

        public async Task<RowListResponse> Aggregation<T>(T param) where T : AggregationInput
        {
            var result = await this._repository.Aggregation(param);
            return result;
        }

        public async Task<RowListResponse> Find<T>(T param) where T : FindInput
        {
            var result = await this._repository.Find(param);
            return result;
        }

        public async Task<RowResponse> FindById<T>(T param) where T : FindByIdInput
        {
            var result = await this._repository.FindById(param);
            return result;
        }

        public async Task<RowResponse> FindByIdAndDelete<T>(T param) where T : FindByIdAndDeleteInput
        {
            var result = await this._repository.FindByIdAndDelete(param);
            return result;
        }

        public async Task<RowResponse> FindByIdAndUpdate<T>(T param) where T : FindByIdAndUpdateInput
        {
            var result = await this._repository.FindByIdAndUpdate(param);
            return result;
        }

        public async Task<RowResponse> Insert<T>(T param) where T : InsertInput
        {
            var result = await this._repository.Insert(param);
            return result;
        }

        public async Task<RowResponse> InsertMany<T>(T param) where T : InsertManyInput
        {
            var result = await this._repository.InsertMany(param);
            return result;
        }

        public async Task<ActionResponse> UpdateMany<T>(T param) where T : UpdateManyInput
        {
            var result = await this._repository.UpdateMany(param);
            return result;
        }

        public async Task<ActionResponse> Delete<T>(T param) where T : DeleteInput
        {
            var result = await this._repository.Delete(param);
            return result;
        }

        public async Task<ActionResponse> DeleteMany<T>(T param) where T : DeleteManyInput
        {
            var result = await this._repository.DeleteMany(param);
            return result;
        }
    }
}