namespace models.inputs
{
    public class FindMyDeviceParams
    {
        public int Skip { get; set; } = 0;
        public int Limit { get; set; } = 25;
    }

    public class RevokeDeviceParams
    {
        public int DeviceId { get; set; }
    }
}