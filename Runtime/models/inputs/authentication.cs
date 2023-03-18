using System;
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
        public string AccessToken { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    [Serializable]
    public class LoginAsGuestParams
    {
        public string DeviceId { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    [Serializable]
    public class LoginWithTokenParams
    {
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
        public string PhoneNumber { get; set; } 
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    [Serializable]
    public class VerifyOtaTokenParams
    {
        public string PhoneNumber { get; set; } 
        public string Name { get; set; }
        public string Token { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}