using System.Threading.Tasks;
using GameService.Client.Sdk.Models.inputs;
using GameService.Client.Sdk.Models.outputs;
using GameService.Client.Sdk.Repositories.Table;
using GameService.Client.Sdk.Utils.WebsocketClient;

namespace GameService.Client.Sdk.Services.Table
{
    public class TableService : ITable
    {
        private TableRepository _repository;

        public TableService(ISocketAgent agent)
        {
            _repository = new TableRepository();
        }

        public async Task<RowListResponse<TY>> Find<TY, T>(T param) where T : FindParams
        {
            var result = await _repository.Find<TY, T>(param);
            return result;
        }

        public async Task<RowResponse<TY>> FindById<TY, T>(T param) where T : FindByIdParams
        {
            var result = await _repository.FindById<TY, T>(param);
            return result;
        }

        public async Task<RowResponse<TY>> FindByIdAndDelete<TY, T>(T param) where T : FindByIdAndDeleteParams
        {
            var result = await _repository.FindByIdAndDelete<TY, T>(param);
            return result;
        }

        public async Task<RowResponse<TY>> FindByIdAndUpdate<TY, T>(T param) where T : FindByIdAndUpdateParams
        {
            var result = await _repository.FindByIdAndUpdate<TY, T>(param);
            return result;
        }

        public async Task<RowResponse<TY>> Insert<TY, T>(T param) where T : InsertParams
        {
            var result = await _repository.Insert<TY, T>(param);
            return result;
        }

        public async Task<RowResponse<TY>> InsertMany<TY, T>(T param) where T : InsertManyParams
        {
            var result = await _repository.InsertMany<TY, T>(param);
            return result;
        }

        public async Task<ActionResponse> UpdateMany<T>(T param) where T : UpdateManyParams
        {
            var result = await _repository.UpdateMany(param);
            return result;
        }

        public async Task<ActionResponse> Delete<T>(T param) where T : DeleteParams
        {
            var result = await _repository.Delete(param);
            return result;
        }

        public async Task<ActionResponse> DeleteMany<T>(T param) where T : DeleteManyParams
        {
            var result = await _repository.DeleteMany(param);
            return result;
        }
    }
}