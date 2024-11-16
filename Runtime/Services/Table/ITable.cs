using System.Threading.Tasks;
using DynamicPixels.GameService.Models;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Services.Table.Models;

namespace DynamicPixels.GameService.Services.Table
{
    public interface ITable
    {
        public Task<RowListResponse<TY>> Find<TY, T>(T param) where T : FindParams where TY : BaseTableModel;
        public Task<RowResponse<TY>> FindById<TY, T>(T param) where T : FindByIdParams where TY : BaseTableModel;
        public Task<RowResponse<TY>> FindByIdAndDelete<TY, T>(T param) where T : FindByIdAndDeleteParams where TY : BaseTableModel;
        public Task<RowResponse<TY>> FindByIdAndUpdate<TY, T>(T param) where T : FindByIdAndUpdateParams where TY : BaseTableModel;
        public Task<RowResponse<TY>> Insert<TY, T>(T param) where T : InsertParams where TY : BaseTableModel;
        public Task<RowResponse<TY>> InsertMany<TY, T>(T param) where T : InsertManyParams where TY : BaseTableModel;
        public Task<ActionResponse> UpdateMany<T>(T param) where T : UpdateManyParams;
        public Task<ActionResponse> Delete<T>(T param) where T : DeleteParams;
        public Task<ActionResponse> DeleteMany<T>(T param) where T : DeleteManyParams;
    }
}