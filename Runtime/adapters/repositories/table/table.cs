using System.IO;
using System.Threading.Tasks;
using models.inputs;
using models.outputs;
using adapters.utils.httpClient;
using ports;
using models;
using UnityEngine;

namespace adapters.repositories.table
{
    public class TableRepository :ITableRepositories
    {

        public TableRepository()
        {
        }

        public async Task<RowListResponse> Aggregation<T>(T input) where T : AggregationInput
        {
            var response = await WebRequest.Post(UrlMap.AggregationUrl(input.TableId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonUtility.FromJson<RowListResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonUtility.FromJson<ErrorResponse>(await reader.ReadToEndAsync()).ToString());
        }

        public async Task<RowListResponse> Find<T>(T input) where T : FindInput
        {
            var response = await WebRequest.Post( UrlMap.FindUrl(input.tableId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonUtility.FromJson<RowListResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonUtility.FromJson<ErrorResponse>(await reader.ReadToEndAsync()).ToString());
        }

        public async Task<RowResponse> FindById<T>(T input) where T : FindByIdInput
        {
            var response = await WebRequest.Post(UrlMap.FindByIdUrl(input.TableId, input.RowId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonUtility.FromJson<RowResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonUtility.FromJson<ErrorResponse>(await reader.ReadToEndAsync()).ToString());
        }

        public async Task<RowResponse> FindByIdAndDelete<T>(T input) where T : FindByIdAndDeleteInput
        {
            var response = await WebRequest.Post(UrlMap.FindByIdAndDeleteUrl(input.TableId, input.RowId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonUtility.FromJson<RowResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonUtility.FromJson<ErrorResponse>(await reader.ReadToEndAsync()).ToString());
        }

        public async Task<RowResponse> FindByIdAndUpdate<T>(T input) where T : FindByIdAndUpdateInput
        {
            var response = await WebRequest.Post(UrlMap.FindByIdAndUpdateUrl(input.TableId, input.RowId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonUtility.FromJson<RowResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonUtility.FromJson<ErrorResponse>(await reader.ReadToEndAsync()).ToString());
        }

        public async Task<RowResponse> Insert<T>(T input) where T : InsertInput
        {
            var response = await WebRequest.Post(UrlMap.InsertUrl(input.TableId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonUtility.FromJson<RowResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonUtility.FromJson<ErrorResponse>(await reader.ReadToEndAsync()).ToString());
        }

        public async Task<RowResponse> InsertMany<T>(T input) where T : InsertManyInput
        {
            var response = await WebRequest.Post(UrlMap.InsertManyUrl(input.TableId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonUtility.FromJson<RowResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonUtility.FromJson<ErrorResponse>(await reader.ReadToEndAsync()).ToString());
        }

        public async Task<ActionResponse> UpdateMany<T>(T input) where T : UpdateManyInput
        {
            var response = await WebRequest.Post( UrlMap.UpdateManyUrl(input.TableId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonUtility.FromJson<ActionResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonUtility.FromJson<ErrorResponse>(await reader.ReadToEndAsync()).ToString());
        }

        public async Task<ActionResponse> Delete<T>(T input) where T : DeleteInput
        {
            var response = await WebRequest.Post(UrlMap.DeleteUrl(input.TableId, input.RowIds), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonUtility.FromJson<ActionResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonUtility.FromJson<ErrorResponse>(await reader.ReadToEndAsync()).ToString());
        }

        public async Task<ActionResponse> DeleteMany<T>(T input) where T : DeleteManyInput
        {
            var response = await WebRequest.Post(UrlMap.DeleteManyUrl(input.TableId), input.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonUtility.FromJson<ActionResponse>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonUtility.FromJson<ErrorResponse>(await reader.ReadToEndAsync()).ToString());
        }
    }
}