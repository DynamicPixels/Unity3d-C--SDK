using System;
using models.dto;
using adapters.services.authentication;
using adapters.services.storage;
using adapters.services.table;
using adapters.utils.WebsocketClient;
using ports;
using models;
using ports.utils;
using UnityEngine;
using Logger = adapters.utils.Logger.Logger;
using LogType = models.dto.LogType;
using SystemInfo = models.dto.SystemInfo;

public static class DynamicPixels
{
    // configs
    internal static string ClientId { get; private set; }
    internal static string ClientSecret { get; private set; }
    internal static string Token { get; set; } = String.Empty;
    internal static User User { get; set; }
    internal static bool IsAvailable;
    
    public static bool DebugMode = false;
    public static bool VerboseMode = false;

    // transports
    internal static ISocketAgent Agent = new WebsocketClient();
    
    // services
    public static IAuthentication Authentication;
    public static IStorage Storage;
    public static ITable Table;
    
    public static void Configure(string clientId, string clientSecret, SystemInfo systemInfo, bool debugMode, bool verboseMode)
    {
        if (IsAvailable)
            Logger.LogException<DynamicPixelsException>(new DynamicPixelsException("Sdk is already initialized, logout first"), DebugLocation.All, "Configure");
        
        ClientId = clientId;
        ClientSecret = clientSecret;
        DebugMode = debugMode;
        VerboseMode = verboseMode;
        
        Logger.onDebugReceived += LoggerOnDebugReceived;
        
        Authentication = new AuthenticationService();
        Table = new TableService(Agent);
        Storage = new StorageService();
    }

    private static void LoggerOnDebugReceived(object sender, DebugArgs debug)
    {
        switch (debug.LogTypeType)
        {
            case LogType.Normal:
                Debug.Log(debug.Data);
                break;
            case LogType.Error:
                Debug.LogError(debug.Data);
                break;
            case LogType.Exception:
                Debug.LogException(debug.Exception);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        // if (!EnableSaveDebugLogs) return;
            
        // if (Directory.Exists(_appPath + DebugPath))
        //     File.AppendAllText(_appPath + DebugPath + _logFile,debug.Data + "\r\n");
    }

    public static bool IsAuthenticated()
    {
        return Token != String.Empty;
    }

    public static string Version()
    {
        return "0.0.1";
    }
}