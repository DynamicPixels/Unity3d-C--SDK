namespace adapters.repositories.table.services.device
{
    public class UrlMap
    {
        public static string FindMyDevicesUrl(int skip, int limit) => $"/api/table/services/devices?skip=${skip}&limit=${limit}";
        public static string RevokeDeviceUrl(int deviceId) => $"/api/table/services/devices/{deviceId}";
    }
}