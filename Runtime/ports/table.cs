using System.Threading.Tasks;
using adapters.services.table;
using models.inputs;
using models.outputs;

namespace ports
{
    public interface ITable
    {
        public DynamicPixelsServices GetServices(); 
        public Task<RowListResponse> Aggregation<T>(T param) where T: AggregationParams;
        public Task<RowListResponse> Find<T>(T param) where T: FindParams;
        public Task<RowResponse> FindById<T>(T param) where T: FindByIdParams;
        public Task<RowResponse> FindByIdAndDelete<T>(T param) where T: FindByIdAndDeleteParams;
        public Task<RowResponse> FindByIdAndUpdate<T>(T param) where T: FindByIdAndUpdateParams;
        public Task<RowResponse> Insert<T>(T param) where T: InsertParams;
        public Task<RowResponse> InsertMany<T>(T param) where T: InsertManyParams;
        public Task<ActionResponse> UpdateMany<T>(T param) where T: UpdateManyParams;
        public Task<ActionResponse> Delete<T>(T param) where T: DeleteParams;
        public Task<ActionResponse> DeleteMany<T>(T param) where T: DeleteManyParams;
    }
}