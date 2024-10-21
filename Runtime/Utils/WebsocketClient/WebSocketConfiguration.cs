using System;

namespace DynamicPixels.GameService.ModuleFramework.Messaging.Models
{
    public class WebSocketConfiguration
    {
        public string WebSocketUrl { get; set; }
        public Uri WebSocketUri { get; set; }
        public short MaxReconnectAttempts { get; set; }
        public short ReconnectDelay { get; set; }
        public short PingInterval { get; set; }
    }
}

