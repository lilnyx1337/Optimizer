using Microsoft.Win32;
using System.Collections.Generic;

namespace FlowOptimizer.Modules
{
    public static class NetworkTweaks
    {
        private static Dictionary<string, (string, string, object, RegistryHive)> originalValues = new Dictionary<string, (string, string, object, RegistryHive)>();

        public static void Apply()
        {
            SetTcpIpParameters();
            SetMsmqParameters();
        }

        public static void Restore()
        {
            foreach (var item in originalValues.Values)
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

        private static void SetTcpIpParameters()
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters", true))
            {
                if (key != null)
                {
                    SaveOriginalValue(key, "DefaultTTL", RegistryHive.LocalMachine);
                    SaveOriginalValue(key, "EnablePMTUBHDetect", RegistryHive.LocalMachine);
                    SaveOriginalValue(key, "EnablePMTUDiscovery", RegistryHive.LocalMachine);
                    SaveOriginalValue(key, "SackOpts", RegistryHive.LocalMachine);
                    SaveOriginalValue(key, "Tcp1323Opts", RegistryHive.LocalMachine);
                    SaveOriginalValue(key, "TcpWindowSize", RegistryHive.LocalMachine);

                    key.SetValue("DefaultTTL", 64, RegistryValueKind.DWord);
                    key.SetValue("EnablePMTUBHDetect", 0, RegistryValueKind.DWord);
                    key.SetValue("EnablePMTUDiscovery", 1, RegistryValueKind.DWord);
                    key.SetValue("SackOpts", 1, RegistryValueKind.DWord);
                    key.SetValue("Tcp1323Opts", 1, RegistryValueKind.DWord);
                    key.SetValue("TcpWindowSize", 65535, RegistryValueKind.DWord);
                }
            }
        }

        private static void SetMsmqParameters()
        {
            // Note: This key might not exist on all systems.
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\MSMQ\Parameters", true);
            if (key == null)
            {
                key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\MSMQ\Parameters");
            }

            if (key != null)
            {
                using (key)
                {
                    SaveOriginalValue(key, "TCPNoDelay", RegistryHive.LocalMachine);
                    key.SetValue("TCPNoDelay", 1, RegistryValueKind.DWord);
                }
            }
        }

        private static void SaveOriginalValue(RegistryKey key, string valueName, RegistryHive hive)
        {
            RegistryKey baseKey = hive == RegistryHive.LocalMachine ? Registry.LocalMachine : Registry.CurrentUser;
            string relativeKeyPath = key.Name.Substring(baseKey.Name.Length + 1);
            string dict_key = relativeKeyPath + @"\" + valueName;

            if (!originalValues.ContainsKey(dict_key))
            {
                originalValues[dict_key] = (relativeKeyPath, valueName, key.GetValue(valueName), hive);
            }
        }
    }
}
