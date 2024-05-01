using System;
using Newtonsoft.Json;

namespace GameService.Client.Sdk.Models.outputs
{
    [Serializable]
    public class ErrorResponse
    {
        [JsonProperty("msg")] public string Message;
        [JsonProperty("status")] public bool Status;
    }
}