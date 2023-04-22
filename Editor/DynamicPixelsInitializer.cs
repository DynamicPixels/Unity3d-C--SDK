using System.Diagnostics;
using System.Net.Mime;
using UnityEngine;
using Debug = UnityEngine.Debug;
using SystemInfo = models.dto.SystemInfo;

namespace DynamicPixelsInitializer
{
    public class DynamicPixelsInitializer : MonoBehaviour
    {
        public string clientId;
        public string clientSecret;
        public bool debugMode = false;
        public bool verboseMode = false;
        
        private static bool _isInit = false;

        void OnDisable()
        {
            Debug.Log("DynamicPixels was disabled");
        }

        void OnEnable()
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
            DynamicPixels.Configure(clientId, clientSecret, systemInfo, debugMode, verboseMode);

            Debug.Log("DynamicPixels Initialized");
        }

    }
}
