using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using models;
using UnityEngine;

namespace adapters.utils.httpClient
{
     internal static class WebRequest
    {
        private static string baseUrl = "http://localhost:5114";

        private static HttpClient _client;
        private static readonly string UserAgent = "UnitySDK-" + BlueG.Version();

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
            if (headers == null) return _client;
            _client.DefaultRequestHeaders.Clear();
            foreach (var header in headers)
                _client.DefaultRequestHeaders.Add(header.Key, header.Value);

            _client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
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


        private static async Task<HttpResponseMessage> DoRequest(string url,
            WebRequestMethod method = WebRequestMethod.Get, 
            string body = null,
            Dictionary<string, string> headers = null
            )
        {
            var httpClient = Init(headers);
            StringContent content = null;
            if (body != null) content = new StringContent(body, Encoding.UTF8, "application/json");
            url = baseUrl + url;
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
                        throw new BlueGException();
                }
            }
            catch (Exception e)
            {
                if (e is OperationCanceledException)
                    throw new BlueGException("Request Timeout");
                throw;
            }
        }
    }
}