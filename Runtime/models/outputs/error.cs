using System;
using Newtonsoft.Json;

namespace models.outputs
{
    [Serializable]
    public class ErrorResponse
    {
        [JsonProperty("msg")] public string Message;
        [JsonProperty("status")] public bool Status;
    }
}