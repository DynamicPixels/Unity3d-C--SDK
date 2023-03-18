using System.Diagnostics;
using System.Net.Mime;
using UnityEngine;
using Debug = UnityEngine.Debug;
using SystemInfo = models.dto.SystemInfo;

namespace BlueGInitializer
{
    public class BlueGInitializer : MonoBehaviour
    {
        public string clientId;
        public string clientSecret;
        public bool debugMode = false;
        public bool verboseMode = false;

        private static bool _isInit = false;

        void OnDisable()
        {
            Debug.Log("BlueG was disabled");
        }

        void OnEnable()
        {
            // dont initialize SDK multiple time 
            if (_isInit || BlueG.IsAuthenticated()) return;
            Debug.Log("BlueG Initializing");

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
            BlueG.Configure(clientId, clientSecret, systemInfo);

            Debug.Log("BlueG Initialized");
        }

    }
}
