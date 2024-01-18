using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using adapters.repositories.authentication;
using models.outputs;
using adapters.utils.httpClient;
using models;
using models.inputs;
using Newtonsoft.Json;
using ports;
using UnityEngine;
using System.Net.Http.Headers;
using System.Text;
namespace adapters.repositories.storage
{
    public class StorageRepository : IStorageRepositories
    {
        public Task<FileMetadata> GetFileInfo(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public Task Download(string fileName)
        {
            throw new System.NotImplementedException();
        }
        public async Task<FileMetaForUpload> UploadFile<T>(T input) where T : FileMetaForUpload
        {
            var fileInfo = new
            {
                file_name = input.Name,
                content_type = input.ContentType
            };

            // Convert the object to JSON
            string json = JsonConvert.SerializeObject(fileInfo, Formatting.Indented);
            string uri = "https://link.dynamicpixels.dev/game/im49q2/api/storage/upload";
            Debug.Log(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await new HttpClient().PostAsync(uri, content);


            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var body = await reader.ReadToEndAsync();
            
            if (response.IsSuccessStatusCode)
            {
                var row = JsonConvert.DeserializeObject<FileMetaForUpload>(body);
                await PutFile(row.row, input.FileContent,input.Name,input.ContentType);

                return JsonConvert.DeserializeObject<FileMetaForUpload>(body);

            }
            else
            {
                // Deserialize the error response
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

                // Get the corresponding ErrorCode from the error message
                var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

                // Throw the DynamicPixelsException with the ErrorCode
                throw new DynamicPixelsException(errorCode, errorResponse?.Message);
            }
        }

        public async Task<FileMetaForUpload> PutFile(string url, string fileContent,string Name,string contenttype)
        {

            Debug.Log(fileContent);

            // Read file content
            byte[] fileData = null;

            try
            {
                fileData = System.IO.File.ReadAllBytes(fileContent);
                
            }
            catch (Exception ex)
            {
                Debug.LogError("Error reading file: " + ex.Message);
            }


            // Create WebRequest


            // Make PUT request using the extension method
            using (var httpClient = new HttpClient())
            {
                using (var content = new ByteArrayContent(fileData))
            {
                    using (var request = new HttpRequestMessage(new HttpMethod("PUT"), url))
                    {
                        request.Content = new StringContent(Name);
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(contenttype);
                        
                        var response = await httpClient.SendAsync(request);
                        using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
                        var body = await reader.ReadToEndAsync();

                        

                        if (response.IsSuccessStatusCode)
                        {
                            return JsonConvert.DeserializeObject<FileMetaForUpload>(body);
                        }
                        else
                        {
                            // Deserialize the error response
                            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(body);

                            // Get the corresponding ErrorCode from the error message
                            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);

                            // Throw the DynamicPixelsException with the ErrorCode
                            throw new DynamicPixelsException(errorCode, errorResponse?.Message);
                        }
                    }

                }
            }
        }
    }
}

