using System;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Authentication.Models
{
    [Serializable]
    public class SendOtaTokenParams
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; } 

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}