namespace DynamicPixels.GameService.Utils.WebsocketClient
{
    public class WebSocketConfiguration
    {
        public string WebSocketUrl { get; set; }
        public short MaxReconnectAttempts { get; set; }
        public short ReconnectDelay { get; set; }
        public short PingInterval { get; set; }
    }
}

