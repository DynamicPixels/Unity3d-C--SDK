using System;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Models.outputs
{
    [Serializable]
    public class ErrorResponse
    {
        [JsonProperty("msg")] public string Message;
        [JsonProperty("status")] public bool Status;
    }
}