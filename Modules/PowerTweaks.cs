using Microsoft.Win32;
using System.Diagnostics;
using System.Collections.Generic;

namespace FlowOptimizer.Modules
{
    public static class PowerTweaks
    {
        private const string UltimatePerformanceGuid = "e9a42b02-d5df-448d-aa00-02f14749eb61";
        private const string HighPerformanceGuid = "8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c";
        private const string BalancedGuid = "381b4222-f694-41f0-9685-ff5bb260df2e";

        private static Dictionary<string, object> originalRegistryValues = new Dictionary<string, object>();
        private static string originalPowerScheme = "";

        public static void Apply()
        {
            SaveOriginalState();

            // Attempt to enable and set Ultimate Performance plan
            ExecutePowerCfg($"/duplicatescheme {HighPerformanceGuid} {UltimatePerformanceGuid}");
            ExecutePowerCfg($"/setactive {UltimatePerformanceGuid}");

            // Disable Hibernation
            ExecutePowerCfg("/hibernate off");

            // Disable Fast Startup
            SetRegistryValue(@"SYSTEM\CurrentControlSet\Control\Session Manager\Power", "HiberbootEnabled", 0);
        }

        public static void Restore()
        {
            // Restore original power scheme
            if (!string.IsNullOrEmpty(originalPowerScheme))
            {
                ExecutePowerCfg($"/setactive {originalPowerScheme}");
            }
            else
            {
                 // Fallback to Balanced
                ExecutePowerCfg($"/setactive {BalancedGuid}");
            }

            // Restore original registry values
            if (originalRegistryValues.TryGetValue("HiberbootEnabled", out object value))
            {
                 SetRegistryValue(@"SYSTEM\CurrentControlSet\Control\Session Manager\Power", "HiberbootEnabled", value);
            }

            // Re-enable hibernation if it was originally on (logic can be improved)
            ExecutePowerCfg("/hibernate on");
        }

        private static void SaveOriginalState()
        {
            // Save current active power scheme
            originalPowerScheme = GetActivePowerScheme();

            // Save original registry values
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Power", true))
            {
                if (key != null)
                {
                    originalRegistryValues["HiberbootEnabled"] = key.GetValue("HiberbootEnabled");
                }
            }
        }

        private static string GetActivePowerScheme()
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powercfg",
                    Arguments = "/getactivescheme",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            // Output is "Power Scheme GUID: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx  (Scheme Name)"
            int guidStart = output.IndexOf(':') + 2;
            int guidEnd = output.IndexOf('(') -1;
            if (guidStart > 1 && guidEnd > guidStart)
            {
                return output.Substring(guidStart, guidEnd - guidStart).Trim();
            }
            return "";
        }

        private static void ExecutePowerCfg(string arguments)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powercfg.exe",
                    Arguments = arguments,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true, // To debug if needed
                    RedirectStandardError = true
                }
            };
            process.Start();
            process.WaitForExit();
        }

        private static void SetRegistryValue(string keyPath, string valueName, object value)
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath, true))
            {
                if (key != null)
                {
                    key.SetValue(valueName, value, RegistryValueKind.DWord);
                }
            }
        }
    }
}
