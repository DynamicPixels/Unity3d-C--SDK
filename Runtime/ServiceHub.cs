using System;
using DynamicPixels.GameService.Models;
using DynamicPixels.GameService.Services.Authentication;
using DynamicPixels.GameService.Services.Storage;
using DynamicPixels.GameService.Services.Synchronise;
using DynamicPixels.GameService.Services.Table;
using DynamicPixels.GameService.Services.User.Models;
using DynamicPixels.GameService.Utils.Logger;
using DynamicPixels.GameService.Utils.WebsocketClient;

namespace DynamicPixels.GameService
{

    public static class ServiceHub
    {
        // configs
        internal static string ClientId { get; private set; }
        internal static string ClientSecret { get; private set; }
        internal static string Token { get; set; } = String.Empty;
        internal static User User { get; set; }
        internal static bool IsAvailable;
        internal static bool DevelopmentMode = false;
        public static bool DebugMode = false;
        public static bool VerboseMode = false;
        public static SystemInfo SystemInfo;


        // transports
        // TODO: Realtime
        internal static ISocketAgent Agent = new WebSocketAgent();

        // services
        public static ISynchronise Synchronise;
        public static IAuthentication Authentication;
        public static IStorage Storage;
        public static ITable Table;
        public static Services.Table.Services Services;

        public static void Configure(string clientId, string clientSecret, SystemInfo systemInfo, bool debugMode,
            bool developmentMode, bool verboseMode)
        {
            if (IsAvailable)
                LogHelper.LogException<DynamicPixelsException>(
                    new DynamicPixelsException(ErrorCode.SdkAlreadyInitialized,
                        "Sdk is already initialized, logout first"),
                    DebugLocation.All,
                    "Configure");

            ClientId = clientId;
            ClientSecret = clientSecret;
            DebugMode = debugMode;
            VerboseMode = verboseMode;
            DevelopmentMode = developmentMode;
            SystemInfo = systemInfo;


            Authentication = new AuthenticationService();
            // TODO: RealTime
            Table = new TableService(Agent);
            Storage = new StorageService();
            Synchronise = new SynchroniseService();
            Services = new Services.Table.Services(Agent);
        }

        public static bool IsAuthenticated()
        {
            return Token != String.Empty;
        }

        public static void Dispose()
        {
            Authentication.Logout();
        }

        public static string Version()
        {
            return "0.0.1";
        }
    }
}