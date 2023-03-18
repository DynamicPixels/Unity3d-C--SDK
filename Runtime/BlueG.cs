using System;
using models.dto;
using adapters.services.authentication;
using adapters.services.storage;
using adapters.services.table;
using ports;
using models;

public static class BlueG
{
    // configs
    internal static string ClientId { get; private set; }
    internal static string ClientSecret { get; private set; }
    internal static string Token { get; set; } = String.Empty;
    internal static User User { get; set; }
    internal static bool IsAvailable;

    // services
    public static IAuthentication Authentication;
    public static IStorage Storage;
    public static ITable Table;

    public static void Configure(string clientId, string clientSecret, SystemInfo systemInfo)
    {
        if (IsAvailable)
            throw new BlueGException("Sdk is already initialized, logout first");
        ClientId = clientId;
        ClientSecret = clientSecret;


        Authentication = new AuthenticationService();
        Table = new TableService();
        Storage = new StorageService();
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