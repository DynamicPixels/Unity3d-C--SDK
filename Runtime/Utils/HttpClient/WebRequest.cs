using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DynamicPixels.GameService.Models;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Utils.Logger;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Utils.HttpClient
{
    internal static class WebRequest
    {
        private static readonly string _baseUrl = ServiceHub.DevelopmentMode
            ? $"http://localhost:5286/game/{ServiceHub.ClientId}"
            : $"https://link.dynamicpixels.dev/game/{ServiceHub.ClientId}";

        private static System.Net.Http.HttpClient _client = new() { Timeout = TimeSpan.FromSeconds(15) };
        private static readonly string _userAgent = "UnitySDK-" + ServiceHub.Version();

        internal static async Task<T> Get<T>(string url, Dictionary<string, string> headers = null)
        {
            var result = await DoRequest(url, HttpMethod.Get, null, headers);
            return JsonConvert.DeserializeObject<T>(result);
        }

        internal static async Task<T> Put<T>(string url, string body = null,
            Dictionary<string, string> headers = null)
        {
            var result = await DoRequest(url, HttpMethod.Put, body, headers);
            return JsonConvert.DeserializeObject<T>(result);
        }

        internal static async Task Put(string url, string body = null,
            Dictionary<string, string> headers = null)
        {
            await DoRequest(url, HttpMethod.Put, body, headers);
        }

        internal static async Task<T> Patch<T>(string url, string body = null,
            Dictionary<string, string> headers = null)
        {
            var result = await DoRequest(url, HttpMethod.Patch, body, headers);
            return JsonConvert.DeserializeObject<T>(result);
        }

        internal static async Task Patch(string url, string body = null,
            Dictionary<string, string> headers = null)
        {
            await DoRequest(url, HttpMethod.Patch, body, headers);
        }

        internal static async Task<T> Post<T>(string url, string body = null,
            Dictionary<string, string> headers = null)
        {
            var result = await DoRequest(url, HttpMethod.Post, body, headers);
            return JsonConvert.DeserializeObject<T>(result);

        }

        internal static async Task Post(string url, string body = null,
            Dictionary<string, string> headers = null)
        {
            await DoRequest(url, HttpMethod.Post, body, headers);
        }

        internal static async Task<T> Delete<T>(string url, Dictionary<string, string> headers = null)
        {
            var result = await DoRequest(url, HttpMethod.Delete, null, headers);
            return JsonConvert.DeserializeObject<T>(result);

        }

        internal static async Task Delete(string url, Dictionary<string, string> headers = null)
        {
            await DoRequest(url, HttpMethod.Delete, null, headers);
        }

        private static async Task<string> DoRequest(
            string url,
            HttpMethod method,
            string body = null,
            Dictionary<string, string> headers = null,
            CancellationToken cancellationToken = default
        )
        {
            url = _baseUrl + url;

            var request = new HttpRequestMessage(method, url);
            var response = await request
                .SetHeaders(headers)
                .AddJsonBody(body)
                .Send(cancellationToken);

            LogHelper.LogNormal<string>(DebugLocation.WebSocket, "DoRequest", $"{url} with body: {body}");


            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var result = await reader.ReadToEndAsync();

            if (response.IsSuccessStatusCode)
                return result;

            LogHelper.LogError<string>(DebugLocation.WebSocket, "DoRequest", $"Server Error: {result}");

            // Deserialize the error response
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(result);

            // Get the corresponding ErrorCode from the error message
            var errorCode = ErrorMapper.GetErrorCode(errorResponse?.Message ?? string.Empty);
            
            if (errorCode == ErrorCode.UnknownError)
                throw new DynamicPixelsException(errorCode, response.ToString());

            // Throw the DynamicPixelsException with the ErrorCode
            throw new DynamicPixelsException(errorCode, errorResponse?.Message);

            //var content = await responseMessage.Content.ReadAsStringAsync();
            //var problemDetails = string.IsNullOrWhiteSpace(content)
            //    ? new() { Title = responseMessage.ReasonPhrase }
            //    : JsonSerializer.Deserialize<ProblemDetails>(content);

            //throw new RestApiClientException(problemDetails);
        }
        
        //internal static async Task<HttpResponseMessage> DoMultiPartPost(string url, byte[] data,
        //    Dictionary<string, string> headers = null)
        //{
        //    var httpClient = SetHeaders(headers);
        //    var dataContent = new MultipartFormDataContent
        //    {
        //        { new ByteArrayContent(data), "file", "file" }
        //    };
        //    return await httpClient.PostAsync(url, dataContent);
        //}

        private static HttpRequestMessage SetHeaders(this HttpRequestMessage request,
            Dictionary<string, string> headers = null)
        {
            if (ServiceHub.Token != string.Empty)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", ServiceHub.Token);

            request.Headers.Add("User-Agent", _userAgent);

            if (headers == null) return request;

            foreach (var header in headers)
                request.Headers.Add(header.Key, header.Value);

            return request;
        }
        private static HttpRequestMessage AddJsonBody(this HttpRequestMessage request, string body)
        {
            if (body is null)
                return request;

            request.Content =
                new StringContent(body, Encoding.UTF8, "application/json");

            return request;
        }

        private static Task<HttpResponseMessage> Send(this HttpRequestMessage request,
            CancellationToken cancellationToken = default)
        {
            return _client.SendAsync(request, cancellationToken);
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
    }
}