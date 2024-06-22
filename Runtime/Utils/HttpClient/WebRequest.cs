using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DynamicPixels.GameService.Models;

namespace DynamicPixels.GameService.Utils.HttpClient
{
    internal static class WebRequest
    {

        private static string _baseUrl =
            !ServiceHub.DevelopmentMode
            ?
                $"https://link.dynamicpixels.dev/game/{ServiceHub.ClientId}"
            :
                $"http://localhost:5286/game/{ServiceHub.ClientId}";

        private static System.Net.Http.HttpClient _client;
        private static readonly string UserAgent = "UnitySDK-" + ServiceHub.Version();

        private static void InitWebRequest()
        {
            if (_client != null) return;

            _client = new System.Net.Http.HttpClient { Timeout = TimeSpan.FromSeconds(15) };
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

        internal static Task<HttpResponseMessage> Post(string url, string body = null,
            Dictionary<string, string> headers = null)
        {
            //try
            //{
                InitWebRequest();
                return DoRequest(url, WebRequestMethod.Post, body, headers);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}
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

        private static System.Net.Http.HttpClient Init(Dictionary<string, string> headers = null)
        {
            _client.DefaultRequestHeaders.Clear();

            if (ServiceHub.Token != string.Empty)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ServiceHub.Token);
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


        private static Task<HttpResponseMessage> DoRequest(
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


            Logger.LogHelper.LogNormal<string>(DebugLocation.Http, "DoRequest", url);

            //try
            //{
                switch (method)
                {
                    case WebRequestMethod.Get:
                        return httpClient.GetAsync(url);
                    case WebRequestMethod.Post:
                        return httpClient.PostAsync(url, content);
                    case WebRequestMethod.Put:
                        return httpClient.PutAsync(url, content);
                    case WebRequestMethod.Delete:
                        return httpClient.DeleteAsync(url);
                    default:
                        throw new DynamicPixelsException(ErrorCode.UnknownError, "Invalid request method");
                }
            //}
            //catch (Exception e)
            //{
            //    if (e is OperationCanceledException)
            //        throw new DynamicPixelsException(ErrorCode.UnknownError, "Request failed: " + e.Message);

            //    // You might want to provide more information or a different error code here
            //    throw new DynamicPixelsException(ErrorCode.UnknownError, "Request failed: " + e.Message);
            //}
        }
    }
}