using System;
using DynamicPixels.GameService.Models;
using DynamicPixels.GameService.Services.Table;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.User.Models
{
    [Serializable]
    public class User : Row
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)] public string Name { get; set; }
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)] public string Email { get; set; }
        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)] public string PhoneNumber { get; set; }
        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)] public string Image { get; set; }
        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)] public string Username { get; set; }
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)] public string Label { get; set; }
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)] public string Tags { get; set; }
        [JsonProperty("is_ban")]
        public bool IsBan { get; set; }
        [JsonProperty("is_tester")]
        public bool IsTester { get; set; }
        [JsonProperty("is_guest")]
        public bool IsGuest { get; set; }
        [JsonProperty("google_token", NullValueHandling = NullValueHandling.Ignore)] public string GoogleToken { get; set; }
        [JsonProperty("fcm_id", NullValueHandling = NullValueHandling.Ignore)] public string FcmId { get; set; }
        [JsonProperty("first_login")]
        public DateTime? FirstLogin { get; set; }
        [JsonProperty("last_login")]
        public DateTime? LastLogin { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Device
    {
        public Device(SystemInfo info)
        {
            DeviceModel = info.DeviceModel;
            DeviceName = info.DeviceName;
            DeviceType = info.DeviceType;
            DeviceId = info.DeviceUniqueId;
            GraphicsDeviceName = info.GraphicsDeviceName;
            GraphicsDeviceVendor = info.GraphicsDeviceVendor;
            GraphicsMemorySize = info.GraphicsMemorySize.ToString();
            ProcessorCount = info.ProcessorCount.ToString();
            ProcessorFrequency = info.ProcessorFrequency.ToString();
            ProcessorType = info.ProcessorType;
            NetworkType = info.NetworkType;
            OperatingSystem = info.OperatingSystem;
        }

        [JsonProperty("device_id")]
        public string DeviceId { get; set; }

        [JsonProperty("first_login")]
        public DateTime? FirstLogin { get; set; }
        [JsonProperty("last_login")]
        public DateTime? LastLogin { get; set; }
        [JsonProperty("package_name", NullValueHandling = NullValueHandling.Ignore)] public string PackageName { get; set; }
        [JsonProperty("sdk_version")] public string SdkVersion { get; set; } = ServiceHub.Version();
        [JsonProperty("version_name", NullValueHandling = NullValueHandling.Ignore)] public string VersionName { get; set; }
        [JsonProperty("version_code", NullValueHandling = NullValueHandling.Ignore)] public string VersionCode { get; set; }
        [JsonProperty("os_api_level", NullValueHandling = NullValueHandling.Ignore)] public string OsApiLevel { get; set; }
        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)] public string From { get; set; }
        [JsonProperty("model", NullValueHandling = NullValueHandling.Ignore)] public string Model { get; set; }
        [JsonProperty("product", NullValueHandling = NullValueHandling.Ignore)] public string Product { get; set; }
        [JsonProperty("carrier_name", NullValueHandling = NullValueHandling.Ignore)] public string CarrierName { get; set; }
        [JsonProperty("manufacturer", NullValueHandling = NullValueHandling.Ignore)] public string Manufacturer { get; set; }
        [JsonProperty("other_tags", NullValueHandling = NullValueHandling.Ignore)] public string OtherTags { get; set; }
        [JsonProperty("screen_width", NullValueHandling = NullValueHandling.Ignore)] public string ScreenWidth { get; set; }
        [JsonProperty("screen_height", NullValueHandling = NullValueHandling.Ignore)] public string ScreenHeight { get; set; }
        [JsonProperty("sdcard_state", NullValueHandling = NullValueHandling.Ignore)] public string SdcardState { get; set; }
        [JsonProperty("game_orientation", NullValueHandling = NullValueHandling.Ignore)] public string GameOrientation { get; set; }

        [JsonProperty("network_type", NullValueHandling = NullValueHandling.Ignore)] public string NetworkType { get; set; }
        [JsonProperty("mac_address", NullValueHandling = NullValueHandling.Ignore)] public string MacAddress { get; set; }
        [JsonProperty("ip_address", NullValueHandling = NullValueHandling.Ignore)] public string IpAddress { get; set; }

        [JsonProperty("device_name")] public string DeviceName { get; set; }
        [JsonProperty("device_model")] public string DeviceModel { get; set; }

        [JsonProperty("device_type")]
        public string DeviceType { get; set; }

        [JsonProperty("operating_system")]
        public string OperatingSystem { get; set; }

        [JsonProperty("processor_type")]
        public string ProcessorType { get; set; }

        [JsonProperty("processor_count")]
        public string ProcessorCount { get; set; }

        [JsonProperty("processor_frequency")]
        public string ProcessorFrequency { get; set; }

        [JsonProperty("graphic_device_name")]
        public string GraphicsDeviceName { get; set; }

        [JsonProperty("graphic_device_vendor")]
        public string GraphicsDeviceVendor { get; set; }

        [JsonProperty("graphic_memory_size")]
        public string GraphicsMemorySize { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}