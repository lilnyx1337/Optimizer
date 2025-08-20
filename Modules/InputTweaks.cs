using Microsoft.Win32;
using System.Collections.Generic;

namespace FlowOptimizer.Modules
{
    public static class InputTweaks
    {
        private static Dictionary<string, (string, string, object)> originalValues = new Dictionary<string, (string, string, object)>();

        public static void Apply()
        {
            // Mouse Tweaks
            SetMouseAcceleration(false);
            SetKeyboardSpeed(true);
        }

        public static void Restore()
        {
            // Restore all saved original values
            foreach (var item in originalValues.Values)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(item.Item1, true))
                {
                    if (key != null)
                    {
                        key.SetValue(item.Item2, item.Item3);
                    }
                }
            }
        }

        private static void SetMouseAcceleration(bool enabled)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Mouse", true))
            {
                if (key != null)
                {
                    SaveOriginalValue(key, "MouseSpeed");
                    SaveOriginalValue(key, "MouseThreshold1");
                    SaveOriginalValue(key, "MouseThreshold2");
                    SaveOriginalValue(key, "MouseSensitivity");

                    if (enabled)
                    {
                        // Restore to default windows values (or some sensible default)
                        key.SetValue("MouseSpeed", "1");
                        key.SetValue("MouseThreshold1", "6");
                        key.SetValue("MouseThreshold2", "10");
                        key.SetValue("MouseSensitivity", "10"); // Default sensitivity
                    }
                    else
                    {
                        // Disable mouse acceleration
                        key.SetValue("MouseSpeed", "0");
                        key.SetValue("MouseThreshold1", "0");
                        key.SetValue("MouseThreshold2", "0");
                    }
                }
            }
        }

        private static void SetKeyboardSpeed(bool fast)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Keyboard", true))
            {
                if (key != null)
                {
                    SaveOriginalValue(key, "KeyboardDelay");
                    SaveOriginalValue(key, "KeyboardSpeed");

                    if(fast)
                    {
                        key.SetValue("KeyboardDelay", "0");
                        key.SetValue("KeyboardSpeed", "31");
                    }
                    else
                    {
                        // Default values
                        key.SetValue("KeyboardDelay", "1");
                        key.SetValue("KeyboardSpeed", "31");
                    }
                }
            }
        }

        private static void SaveOriginalValue(RegistryKey key, string valueName)
        {
            // We store the key path relative to CurrentUser, since all keys in this module are under HKCU.
            string relativeKeyPath = key.Name.Substring(Registry.CurrentUser.Name.Length + 1);
            string dict_key = relativeKeyPath + @"\" + valueName;

            if (!originalValues.ContainsKey(dict_key))
            {
                originalValues[dict_key] = (relativeKeyPath, valueName, key.GetValue(valueName));
            }
        }
    }
}
