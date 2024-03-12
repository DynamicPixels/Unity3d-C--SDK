using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace models.dto
{
        public class Device
        {

                public Device(SystemInfo info)
                {
                        this.DeviceModel = info.DeviceModel;
                        this.DeviceName = info.DeviceName;
                        this.DeviceType = info.DeviceType;
                        this.DeviceId = info.DeviceUniqueId;
                        this.GraphicsDeviceName = info.GraphicsDeviceName;
                        this.GraphicsDeviceVendor = info.GraphicsDeviceVendor;
                        this.GraphicsMemorySize = info.GraphicsMemorySize.ToString();
                        this.ProcessorCount = info.ProcessorCount.ToString();
                        this.ProcessorFrequency = info.ProcessorFrequency.ToString();
                        this.ProcessorType = info.ProcessorType;
                        this.NetworkType = info.NetworkType;
                        this.OperatingSystem = info.OperatingSystem;
                }

                [JsonProperty("device_id")]
                public string DeviceId { get; set; }

                [JsonProperty("first_login")]
                public DateTime? FirstLogin { get; set; }
                [JsonProperty("last_login")]
                public DateTime? LastLogin { get; set; }
                [JsonProperty("package_name")] [CanBeNull] public string PackageName { get; set; }
                [JsonProperty("sdk_version")] public string SdkVersion { get; set; } = DynamicPixels.Version();
                [JsonProperty("version_name")] [CanBeNull] public string VersionName { get; set; }
                [JsonProperty("version_code")] [CanBeNull] public string VersionCode { get; set; }
                [JsonProperty("os_api_level")] [CanBeNull] public string OsApiLevel { get; set; }
                [JsonProperty("from")] [CanBeNull] public string From { get; set; }
                [JsonProperty("model")] [CanBeNull] public string Model { get; set; }
                [JsonProperty("product")] [CanBeNull] public string Product { get; set; }
                [JsonProperty("carrier_name")] [CanBeNull] public string CarrierName { get; set; }
                [JsonProperty("manufacturer")] [CanBeNull] public string Manufacturer { get; set; }
                [JsonProperty("other_tags")] [CanBeNull] public string OtherTags { get; set; }
                [JsonProperty("screen_width")] [CanBeNull] public string ScreenWidth { get; set; }
                [JsonProperty("screen_height")] [CanBeNull] public string ScreenHeight { get; set; }
                [JsonProperty("sdcard_state")] [CanBeNull] public string SdcardState { get; set; }
                [JsonProperty("game_orientation")] [CanBeNull] public string GameOrientation { get; set; }

                [JsonProperty("network_type")] [CanBeNull] public string NetworkType { get; set; }
                [JsonProperty("mac_address")] [CanBeNull] public string MacAddress { get; set; }
                [JsonProperty("ip_address")] [CanBeNull] public string IpAddress { get; set; }

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