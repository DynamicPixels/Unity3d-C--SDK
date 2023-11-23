using System.IO;
using System.Threading.Tasks;
using models.outputs;
using adapters.utils.httpClient;
using ports;
using models;
using models.inputs;
using Newtonsoft.Json;
using UnityEngine;

namespace adapters.repositories.table
{
    public class TableRepository :ITableRepositories
    {
        public async Task<RowListResponse<TY>> Find<TY, T>(T Params) where T : FindParams
        {
            var response = await WebRequest.Put( UrlMap.FindUrl(Params.tableId, Params.options.Skip, Params.options.Limit), Params.options.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            Debug.Log(body);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowListResponse<TY>>(body);

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body).ToString());
        }

        public async Task<RowResponse<TY>> FindById<TY, T>(T Params) where T : FindByIdParams
        {
            var response = await WebRequest.Get(UrlMap.FindByIdUrl(Params.TableId, Params.RowId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<TY>>(body);

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body).ToString());
        }

        public async Task<RowResponse<TY>> FindByIdAndDelete<TY, T>(T Params) where T : FindByIdAndDeleteParams
        {
            var response = await WebRequest.Delete(UrlMap.FindByIdAndDeleteUrl(Params.TableId, Params.RowId));
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<TY>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync()).ToString());
        }

        public async Task<RowResponse<TY>> FindByIdAndUpdate<TY, T>(T Params) where T : FindByIdAndUpdateParams
        {
            var response = await WebRequest.Put(UrlMap.FindByIdAndUpdateUrl(Params.TableId, Params.RowId), Params.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<TY>>(body);

            Debug.Log(body);
            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body).ToString());
        }

        public async Task<RowResponse<TY>> Insert<TY, T>(T Params) where T : InsertParams
        {
            var response = await WebRequest.Post(UrlMap.InsertUrl(Params.TableId), Params.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<TY>>(body);

            Debug.Log(body);
            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body).ToString());
        }

        public async Task<RowResponse<TY>> InsertMany<TY, T>(T Params) where T : InsertManyParams
        {
            var response = await WebRequest.Post(UrlMap.InsertManyUrl(Params.TableId), Params.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<RowResponse<TY>>(await reader.ReadToEndAsync());

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(await reader.ReadToEndAsync()).ToString());
        }

        public async Task<ActionResponse> UpdateMany<T>(T Params) where T : UpdateManyParams
        {
            var response = await WebRequest.Put(UrlMap.UpdateManyUrl(Params.TableId), Params.Options.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ActionResponse>(await reader.ReadToEndAsync());
            Debug.Log(body);

            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body).ToString());
        }

        public async Task<ActionResponse> Delete<T>(T Params) where T : DeleteParams
        {
            var response = await WebRequest.Post(UrlMap.DeleteManyUrl(Params.TableId), Params.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ActionResponse>(body);

            Debug.Log(body);
            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body).ToString());
        }

        public async Task<ActionResponse> DeleteMany<T>(T Params) where T : DeleteManyParams
        {
            var response = await WebRequest.Put(UrlMap.DeleteManyUrl(Params.TableId), Params.Options.ToString());
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ActionResponse>(await reader.ReadToEndAsync());
            Debug.Log(body);
            throw new DynamicPixelsException(JsonConvert.DeserializeObject<ErrorResponse>(body).ToString());
        }
    }
}