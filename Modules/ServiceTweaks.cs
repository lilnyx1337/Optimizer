using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ServiceProcess;

namespace FlowOptimizer.Modules
{
    public static class ServiceTweaks
    {
        private static readonly List<string> servicesToDisable = new List<string>
        {
            "DiagTrack",      // Connected User Experiences and Telemetry
            "dmwappushservice", // Device Management Wireless Application Protocol (WAP) Push message Routing Service
            "XblAuthManager",   // Xbox Live Auth Manager
            "XblGameSave",      // Xbox Live Game Save
            "XboxGipSvc",       // Xbox Accessory Management Service
            "XboxNetApiSvc"     // Xbox Live Networking Service
        };

        private static Dictionary<string, object> originalServiceValues = new Dictionary<string, object>();
        private static Dictionary<string, (string, string, object, RegistryHive)> originalRegistryValues = new Dictionary<string, (string, string, object, RegistryHive)>();

        public static void Apply()
        {
            // Disable Services
            foreach (var serviceName in servicesToDisable)
            {
                try
                {
                    ServiceController sc = new ServiceController(serviceName);
                    if (sc != null)
                    {
                        // Save original start type
                        SaveOriginalServiceState(serviceName);

                        // Stop and disable the service
                        if (sc.Status == ServiceControllerStatus.Running)
                        {
                            sc.Stop();
                            sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                        }
                        SetServiceStartType(serviceName, ServiceStartMode.Disabled);
                    }
                }
                catch (Exception) { /* Ignore errors for non-existent services */ }
            }

            // Disable GameDVR
            SaveOriginalRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\GameDVR", "AllowGameDVR", RegistryHive.CurrentUser);
            SetRegistryValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\GameDVR", "AllowGameDVR", 0, Registry.CurrentUser);
        }

        public static void Restore()
        {
            // Restore Services
            foreach (var serviceName in servicesToDisable)
            {
                if (originalServiceValues.TryGetValue(serviceName, out object startMode))
                {
                    SetServiceStartType(serviceName, (ServiceStartMode)startMode);
                }
            }

            // Restore GameDVR
            foreach (var item in originalRegistryValues.Values)
            {
                RegistryKey baseKey = item.Item4 == RegistryHive.LocalMachine ? Registry.LocalMachine : Registry.CurrentUser;
                using (RegistryKey key = baseKey.OpenSubKey(item.Item1, true))
                {
                    if (key != null)
                    {
                        if (item.Item3 != null)
                        {
                            key.SetValue(item.Item2, item.Item3);
                        }
                        else
                        {
                            key.DeleteValue(item.Item2, false);
                        }
                    }
                }
            }
        }

        private static void SaveOriginalServiceState(string serviceName)
        {
            if (!originalServiceValues.ContainsKey(serviceName))
            {
                originalServiceValues[serviceName] = GetServiceStartMode(serviceName);
            }
        }

        private static void SaveOriginalRegistryValue(string keyPath, string valueName, RegistryHive hive)
        {
            string dictKey = keyPath + @"\" + valueName;
            if (!originalRegistryValues.ContainsKey(dictKey))
            {
                RegistryKey baseKey = hive == RegistryHive.LocalMachine ? Registry.LocalMachine : Registry.CurrentUser;
                using (RegistryKey key = baseKey.OpenSubKey(keyPath, false))
                {
                    if (key != null)
                    {
                        originalRegistryValues[dictKey] = (keyPath, valueName, key.GetValue(valueName), hive);
                    }
                    else
                    {
                        originalRegistryValues[dictKey] = (keyPath, valueName, null, hive);
                    }
                }
            }
        }

        private static ServiceStartMode GetServiceStartMode(string serviceName)
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey($@"SYSTEM\CurrentControlSet\Services\{serviceName}", false))
            {
                if (key != null)
                {
                    var startValue = key.GetValue("Start");
                    if (startValue != null)
                    {
                        return (ServiceStartMode)Convert.ToInt32(startValue);
                    }
                }
            }
            return ServiceStartMode.Manual; // Default fallback
        }

        private static void SetServiceStartType(string serviceName, ServiceStartMode startMode)
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey($@"SYSTEM\CurrentControlSet\Services\{serviceName}", true))
            {
                if (key != null)
                {
                    key.SetValue("Start", (int)startMode, RegistryValueKind.DWord);
                }
            }
        }

        private static void SetRegistryValue(string keyPath, string valueName, object value, RegistryKey baseKey)
        {
            using (RegistryKey key = baseKey.OpenSubKey(keyPath, true) ?? baseKey.CreateSubKey(keyPath))
            {
                if (key != null)
                {
                    key.SetValue(valueName, value, RegistryValueKind.DWord);
                }
            }
        }
    }
}
