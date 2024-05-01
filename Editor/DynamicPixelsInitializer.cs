using System;
using GameService.Client.Sdk;
using GameService.Client.Sdk.Models;
using UnityEngine;
using Debug = UnityEngine.Debug;
using LogType = GameService.Client.Sdk.Models.LogType;
using Logger = GameService.Client.Sdk.Adapters.Utils.Logger.Logger;
using SystemInfo = GameService.Client.Sdk.Models.SystemInfo;

namespace DynamicPixelsInitializer
{
    public class DynamicPixelsInitializer : MonoBehaviour
    {
        public string clientId;
        public string clientSecret;
        public bool developmentMode;
        public bool debugMode = false;
        public bool verboseMode = false;
        
        private static bool _isInit = false;

        public void OnDisable()
        {
            Debug.Log("DynamicPixels was disabled");
            DynamicPixelsDispose();
        }
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void OnEnable()
        {
            // dont initialize SDK multiple time 
            if (_isInit || DynamicPixels.IsAuthenticated()) return;
            Debug.Log("DynamicPixels Initializing");

            // getting system info
            var systemInfo = new SystemInfo()
            {
                DeviceUniqueId = UnityEngine.SystemInfo.deviceUniqueIdentifier,
                DeviceModel = UnityEngine.SystemInfo.deviceModel,
                DeviceName = UnityEngine.SystemInfo.deviceName,
                DeviceType = UnityEngine.SystemInfo.deviceType.ToString(),
                OperatingSystem = UnityEngine.SystemInfo.operatingSystem,
                NetworkType = UnityEngine.Application.internetReachability.ToString(),
                ProcessorCount = UnityEngine.SystemInfo.processorCount,
                ProcessorFrequency = UnityEngine.SystemInfo.processorFrequency,
                ProcessorType = UnityEngine.SystemInfo.processorType,
                GraphicsDeviceName = UnityEngine.SystemInfo.graphicsDeviceName,
                GraphicsDeviceVendor = UnityEngine.SystemInfo.graphicsDeviceVendor,
                GraphicsMemorySize = UnityEngine.SystemInfo.graphicsMemorySize
            };

            // configure Sdk instance
            DynamicPixels.Configure(clientId, clientSecret, systemInfo, debugMode, developmentMode, verboseMode);

            Logger.OnDebugReceived += LoggerOnDebugReceived;

            _isInit = true;
            Debug.Log("DynamicPixels Initialized");
        }

        private void OnDestroy()
        {
            DynamicPixelsDispose();
        }

        private void OnApplicationQuit()
        {
            DynamicPixelsDispose();
        }

        private void DynamicPixelsDispose()
        {
            if(!_isInit) return;
            
            _isInit = false;

            Debug.Log("DynamicPixels Disposed");
 
            DynamicPixels.Dispose();
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
    }
}
