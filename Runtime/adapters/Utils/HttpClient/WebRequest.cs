using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using models;
using models.dto;

namespace adapters.utils.httpClient
{
     internal static class WebRequest
    {
        
        private static string _baseUrl = 
            !DynamicPixels.DevelopmentMode
            ?
                $"https://link.dynamicpixels.dev/game/{DynamicPixels.ClientId}" 
            :
                $"http://localhost:5114/game/{DynamicPixels.ClientId}";

        private static HttpClient _client;
        private static readonly string UserAgent = "UnitySDK-" + DynamicPixels.Version();

        private static void InitWebRequest()
        {
            if (_client != null) return;

            _client = new HttpClient {Timeout = TimeSpan.FromSeconds(15)};
        }

        internal static async Task<HttpResponseMessage> Get(string url, Dictionary<string, string> headers = null)
        {
            InitWebRequest();
            return await DoRequest(url, WebRequestMethod.Get, null, headers);
        }

        internal static async Task<HttpResponseMessage> Put(string url, string body = null,
            Dictionary<string, string> headers = null)
        {
            InitWebRequest();
            return await DoRequest(url, WebRequestMethod.Put, body, headers);
        }

        internal static async Task<HttpResponseMessage> Post(string url, string body = null,
            Dictionary<string, string> headers = null)
        {
            InitWebRequest();
            return await DoRequest(url, WebRequestMethod.Post, body, headers);
        }

        internal static async Task<HttpResponseMessage> Delete(string url, Dictionary<string, string> headers = null)
        {
            InitWebRequest();
            return await DoRequest(url, WebRequestMethod.Delete, null, headers);
        }

        internal static async Task<HttpResponseMessage> DoMultiPartPost(string url, byte[] data,
            Dictionary<string, string> headers = null)
        {
            InitWebRequest();

            var httpClient = Init(headers);
            var dataContent = new MultipartFormDataContent
            {
                {new ByteArrayContent(data), "file", "file"}
            };
            return await httpClient.PostAsync(url, dataContent);
        }

        private static HttpClient Init(Dictionary<string, string> headers = null)
        {
            _client.DefaultRequestHeaders.Clear();

            if (DynamicPixels.Token != string.Empty)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", DynamicPixels.Token);
            }
            
            _client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            
            if (headers == null) return _client;
            foreach (var header in headers)
                _client.DefaultRequestHeaders.Add(header.Key, header.Value);
            
            return _client;
        }


        internal static void Dispose()
        {
            try
            {
                _client?.Dispose();
                _client = null;
            }
            catch (Exception)
            {
                // ignored
            }
        }


        private static async Task<HttpResponseMessage> DoRequest(
            string url,
            WebRequestMethod method = WebRequestMethod.Get, 
            string body = null,
            Dictionary<string, string> headers = null
        )
        {
            var httpClient = Init(headers);
            StringContent content = null;
            if (body != null) content = new StringContent(body, Encoding.UTF8, "application/json");
            url = _baseUrl + url;
            

            Logger.Logger.LogNormal<string>(DebugLocation.Http, "DoRequest", url);
            
            try
            {
                switch (method)
                {
                    case WebRequestMethod.Get:
                        return await httpClient.GetAsync(url);
                    case WebRequestMethod.Post:
                        return await httpClient.PostAsync(url, content);
                    case WebRequestMethod.Put:
                        return await httpClient.PutAsync(url, content);
                    case WebRequestMethod.Delete:
                        return await httpClient.DeleteAsync(url);
                    default:
                        throw new DynamicPixelsException(ErrorCode.UnknownError, "Invalid request method");
                }
            }
            catch (Exception e)
            {
                if (e is OperationCanceledException)
                    throw new DynamicPixelsException(ErrorCode.UnknownError, "Request failed: " + e.Message);

                // You might want to provide more information or a different error code here
                throw new DynamicPixelsException(ErrorCode.UnknownError, "Request failed: " + e.Message);
            }
        }
    }
}