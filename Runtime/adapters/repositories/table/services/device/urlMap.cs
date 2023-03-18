namespace adapters.repositories.table.services.device
{
    public class UrlMap
    {
        public const string FindMyDevicesUrl = "api/table/services/devices";
        public static string RevokeDeviceUrl(string deviceId) => $"api/table/services/devices/{deviceId}";
    }
}