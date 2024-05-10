using System;
using GameService.Client.Sdk.Adapters.Utils.WebsocketClient;
using GameService.Client.Sdk.Models;
using GameService.Client.Sdk.Services.Authentication;
using GameService.Client.Sdk.Services.Services.User;
using GameService.Client.Sdk.Services.Storage;
using GameService.Client.Sdk.Services.Synchronise;
using GameService.Client.Sdk.Services.Table;
using GameService.Client.Sdk.Utils.Logger;
using GameService.Client.Sdk.Utils.WebsocketClient;

namespace GameService.Client.Sdk
{

    public static class DynamicPixels
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
            //Table = new TableService(Agent);
            Storage = new StorageService();
            Synchronise = new SynchroniseService();
            //Services = new Services(Agent);
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