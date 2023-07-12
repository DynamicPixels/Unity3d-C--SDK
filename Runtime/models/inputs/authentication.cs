using System;
using models.dto;
using Newtonsoft.Json;
using UnityEngine;

namespace models.inputs
{
    [Serializable]
    public class RegisterWithEmailParams
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    [Serializable]
    public class LoginWithEmailParams
    {
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    [Serializable]
    public class LoginWithGoogleParams
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    [Serializable]
    public class LoginAsGuestParams
    {
        [JsonProperty("device_id")]
        public string deviceId = "";
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    [Serializable]
    public class LoginWithTokenParams
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    [Serializable]
    public class IsOtaReadyParams
    {
        
    }

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

    [Serializable]
    public class VerifyOtaTokenParams
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; } 

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}