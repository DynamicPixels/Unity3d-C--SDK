using System.Threading.Tasks;
using DynamicPixels.GameService.Models;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Services.Table.Models;
using DynamicPixels.GameService.Services.Table.Repositories;

namespace DynamicPixels.GameService.Services.Table
{
    /// <summary>
    /// Provides services for table-related operations, including finding, updating, and deleting table rows.
    /// </summary>
    public class TableService : ITable
    {
        private readonly TableRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableService"/> class.
        /// </summary>
        public TableService()
        {
            _repository = new TableRepository();
        }

        /// <summary>
        /// Finds rows in a table based on the provided parameters.
        /// </summary>
        /// <typeparam name="TY">The type of the table row model.</typeparam>
        /// <typeparam name="T">The type of the find parameters.</typeparam>
        /// <param name="param">The parameters for finding rows.</param>
        /// <returns>A task representing the asynchronous operation, with a result of a list of rows.</returns>
        public async Task<RowListResponse<TY>> Find<TY, T>(T param) where T : FindParams where TY : BaseTableModel
        {
            var result = await _repository.Find<TY, T>(param);
            return result;
        }

        /// <summary>
        /// Finds a row by its unique identifier.
        /// </summary>
        /// <typeparam name="TY">The type of the table row model.</typeparam>
        /// <typeparam name="T">The type of the find parameters.</typeparam>
        /// <param name="param">The parameters containing the ID of the row to find.</param>
        /// <returns>A task representing the asynchronous operation, with a result of the row found.</returns>
        public async Task<RowResponse<TY>> FindById<TY, T>(T param) where T : FindByIdParams where TY : BaseTableModel
        {
            var result = await _repository.FindById<TY, T>(param);
            return result;
        }

        /// <summary>
        /// Finds and deletes a row by its unique identifier.
        /// </summary>
        /// <typeparam name="TY">The type of the table row model.</typeparam>
        /// <typeparam name="T">The type of the find and delete parameters.</typeparam>
        /// <param name="param">The parameters containing the ID of the row to delete.</param>
        /// <returns>A task representing the asynchronous operation, with a result of the deleted row.</returns>
        public async Task<RowResponse<TY>> FindByIdAndDelete<TY, T>(T param) where T : FindByIdAndDeleteParams where TY : BaseTableModel
        {
            var result = await _repository.FindByIdAndDelete<TY, T>(param);
            return result;
        }

        /// <summary>
        /// Finds a row by its unique identifier and updates it.
        /// </summary>
        /// <typeparam name="TY">The type of the table row model.</typeparam>
        /// <typeparam name="T">The type of the update parameters.</typeparam>
        /// <param name="param">The parameters containing the ID of the row to update and the updated data.</param>
        /// <returns>A task representing the asynchronous operation, with a result of the updated row.</returns>
        public async Task<RowResponse<TY>> FindByIdAndUpdate<TY, T>(T param) where T : FindByIdAndUpdateParams where TY : BaseTableModel
        {
            var result = await _repository.FindByIdAndUpdate<TY, T>(param);
            return result;
        }

        /// <summary>
        /// Inserts a new row into the table.
        /// </summary>
        /// <typeparam name="TY">The type of the table row model.</typeparam>
        /// <typeparam name="T">The type of the insert parameters.</typeparam>
        /// <param name="param">The parameters containing the data of the new row to insert.</param>
        /// <returns>A task representing the asynchronous operation, with a result of the inserted row.</returns>
        public async Task<RowResponse<TY>> Insert<TY, T>(T param) where T : InsertParams where TY : BaseTableModel
        {
            var result = await _repository.Insert<TY, T>(param);
            return result;
        }

        /// <summary>
        /// Inserts multiple new rows into the table.
        /// </summary>
        /// <typeparam name="TY">The type of the table row model.</typeparam>
        /// <typeparam name="T">The type of the insert parameters.</typeparam>
        /// <param name="param">The parameters containing the data of the rows to insert.</param>
        /// <returns>A task representing the asynchronous operation, with a result of the inserted rows.</returns>
        public async Task<RowResponse<TY>> InsertMany<TY, T>(T param) where T : InsertManyParams where TY : BaseTableModel
        {
            var result = await _repository.InsertMany<TY, T>(param);
            return result;
        }

        /// <summary>
        /// Updates multiple rows in the table.
        /// </summary>
        /// <typeparam name="T">The type of the update parameters.</typeparam>
        /// <param name="param">The parameters containing the data for updating rows.</param>
        /// <returns>A task representing the asynchronous operation, with a result indicating the success of the operation.</returns>
        public async Task<ActionResponse> UpdateMany<T>(T param) where T : UpdateManyParams
        {
            var result = await _repository.UpdateMany(param);
            return result;
        }

        /// <summary>
        /// Deletes a row from the table.
        /// </summary>
        /// <typeparam name="T">The type of the delete parameters.</typeparam>
        /// <param name="param">The parameters containing the data of the row to delete.</param>
        /// <returns>A task representing the asynchronous operation, with a result indicating the success of the operation.</returns>
        public async Task<ActionResponse> Delete<T>(T param) where T : DeleteParams
        {
            var result = await _repository.Delete(param);
            return result;
        }

        /// <summary>
        /// Deletes multiple rows from the table.
        /// </summary>
        /// <typeparam name="T">The type of the delete parameters.</typeparam>
        /// <param name="param">The parameters containing the data of the rows to delete.</param>
        /// <returns>A task representing the asynchronous operation, with a result indicating the success of the operation.</returns>
        public async Task<ActionResponse> DeleteMany<T>(T param) where T : DeleteManyParams
        {
            var result = await _repository.DeleteMany(param);
            return result;
        }
    }
}
