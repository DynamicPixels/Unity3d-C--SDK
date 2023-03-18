using System.Threading.Tasks;
using adapters.services.table;
using models.inputs;
using models.outputs;

namespace ports
{
    public interface ITable
    {
        public BlueGServices GetServices(); 
        public Task<RowListResponse> Aggregation<T>(T param) where T: AggregationInput;
        public Task<RowListResponse> Find<T>(T param) where T: FindInput;
        public Task<RowResponse> FindById<T>(T param) where T: FindByIdInput;
        public Task<RowResponse> FindByIdAndDelete<T>(T param) where T: FindByIdAndDeleteInput;
        public Task<RowResponse> FindByIdAndUpdate<T>(T param) where T: FindByIdAndUpdateInput;
        public Task<RowResponse> Insert<T>(T param) where T: InsertInput;
        public Task<RowResponse> InsertMany<T>(T param) where T: InsertManyInput;
        public Task<ActionResponse> UpdateMany<T>(T param) where T: UpdateManyInput;
        public Task<ActionResponse> Delete<T>(T param) where T: DeleteInput;
        public Task<ActionResponse> DeleteMany<T>(T param) where T: DeleteManyInput;
    }
}