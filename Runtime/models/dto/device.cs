using System;
using Newtonsoft.Json;
using UnityEngine;

namespace models.dto
{
    public class Device
    {
        
        [JsonProperty("device_id")]
        public string DeviceId { get; set; } = UnityEngine.SystemInfo.deviceUniqueIdentifier;

        [JsonProperty("first_login")]
        public DateTime? FirstLogin { get; set; }
        [JsonProperty("last_login")]
        public DateTime? LastLogin { get; set; }
        [JsonProperty("package_name")]
        public string? PackageName { get; set; }

        [JsonProperty("sdk_version")] public string SdkVersion { get; set; } = DynamicPixels.Version();
        [JsonProperty("version_name")]
        public string? VersionName { get; set; }
        [JsonProperty("version_code")]
        public string? VersionCode { get; set; }
        [JsonProperty("os_api_lavel")]
        public string? OsApiLevel { get; set; }
        [JsonProperty("device")]
        public string? _Device { get; set; }
        [JsonProperty("from")]
        public string? From { get; set; }
        [JsonProperty("model")]
        public string? Model { get; set; }
        [JsonProperty("product")]
        public string? Product { get; set; }
        [JsonProperty("carrier_name")]
        public string? CarrierName { get; set; }
        [JsonProperty("manufacturer")]
        public string? Manufacturer { get; set; }
        [JsonProperty("other_tags")]
        public string? OtherTags { get; set; }
        [JsonProperty("screen_width")]
        public string? ScreenWidth { get; set; }
        [JsonProperty("screen_height")]
        public string? ScreenHeight { get; set; }
        [JsonProperty("sdcard_state")]
        public string? SdcardState { get; set; }
        [JsonProperty("game_orientation")]
        public string? GameOrientation { get; set; }

        [JsonProperty("network_type")]
        public string? NetworkType { get; set; } = Application.internetReachability.ToString();
        [JsonProperty("mac_address")]
        public string? MacAddress { get; set; }
        [JsonProperty("ip_address")]
        public string? IpAddress { get; set; }

        [JsonProperty("device_name")] public string DeviceName { get; set; } = UnityEngine.SystemInfo.deviceName;
        [JsonProperty("device_model")] public string DeviceModel { get; set; } = UnityEngine.SystemInfo.deviceModel;

        [JsonProperty("device_type")]
        public string DeviceType { get; set; } = UnityEngine.SystemInfo.deviceType.ToString();

        [JsonProperty("operating_system")]
        public string OperatingSystem { get; set; } = UnityEngine.SystemInfo.operatingSystem;

        [JsonProperty("processor_type")]
        public string ProcessorType { get; set; } = UnityEngine.SystemInfo.processorType;

        [JsonProperty("processor_count")]
        public int ProcessorCount { get; set; } = UnityEngine.SystemInfo.processorCount;

        [JsonProperty("processor_frequency")]
        public int ProcessorFrequency { get; set; } = UnityEngine.SystemInfo.processorFrequency;

        [JsonProperty("graphic_device_name")]
        public string GraphicsDeviceName { get; set; } = UnityEngine.SystemInfo.graphicsDeviceName;

        [JsonProperty("graphic_device_vendor")]
        public string GraphicsDeviceVendor { get; set; } = UnityEngine.SystemInfo.graphicsDeviceVendor;

        [JsonProperty("graphic_memory_size")]
        public int GraphicsMemorySize { get; set; } = UnityEngine.SystemInfo.graphicsMemorySize;
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}