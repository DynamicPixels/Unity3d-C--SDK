using System;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Models
{
    /// <summary>
    ///     Represents System Info In DynamicPixels
    /// </summary>
    [Serializable]
    public class SystemInfo
    {
        [JsonProperty("DeviceModel")] public string DeviceModel;
        [JsonProperty("DeviceName")] public string DeviceName;
        [JsonProperty("DeviceType")] public string DeviceType;
        [JsonProperty("DeviceId")] public string DeviceUniqueId;
        [JsonProperty("GraphicsDeviceName")] public string GraphicsDeviceName;
        [JsonProperty("GraphicsDeviceVendor")] public string GraphicsDeviceVendor;
        [JsonProperty("GraphicsMemorySize")] public int GraphicsMemorySize;
        [JsonProperty("NetworkType")] public string NetworkType;
        [JsonProperty("OperatingSystem")] public string OperatingSystem;
        [JsonProperty("ProcessorCount")] public int ProcessorCount;
        [JsonProperty("ProcessorFrequency")] public int ProcessorFrequency;
        [JsonProperty("ProcessorType")] public string ProcessorType;
    }
}