using System;
using Newtonsoft.Json;

namespace models.dto
{
    public class Device
    {
        public int User { get; set; }
        public string DeviceId { get; set; }
        public DateTime FirstLogin { get; set; }
        public DateTime LastLogin { get; set; }
        public string PackageName { get; set; }
        public string SdkVersion { get; set; }
        public string VersionName { get; set; }
        public string VersionCode { get; set; }
        public string OsApiLevel { get; set; }
        public string _Device { get; set; }
        public string From { get; set; }
        public string Model { get; set; }
        public string Product { get; set; }
        public string CarrierName { get; set; }
        public string Manufacturer { get; set; }
        public string OtherTags { get; set; }
        public string ScreenWidth { get; set; }
        public string ScreenHeight { get; set; }
        public string SdcardState { get; set; }
        public string GameOrientation { get; set; }
        public string NetworkType { get; set; }
        public string MacAddress { get; set; }
        public string IpAddress { get; set; }
        public string DeviceName { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceType { get; set; }
        public string OperatingSystem { get; set; }
        public string ProcessorType { get; set; }
        public string ProcessorCount { get; set; }
        public string ProcessorFrequency { get; set; }
        public string GraphicsDeviceName { get; set; }
        public string GraphicsDeviceVendor { get; set; }
        public string GraphicsMemorySize { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}