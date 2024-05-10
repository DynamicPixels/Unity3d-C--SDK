namespace GameService.Client.Sdk.Repositories.Services.Device
{
    public class UrlMap
    {
        public static string FindMyDevicesUrl => $"/api/table/services/devices";
        public static string RevokeDeviceUrl(int deviceId) => $"/api/table/services/devices/{deviceId}";
    }
}