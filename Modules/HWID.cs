using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace FlowOptimizer.Modules
{
    public static class HWID
    {
        public static string Generate()
        {
            try
            {
                string cpuId = GetIdentifier("Win32_Processor", "ProcessorId");
                string motherboardId = GetIdentifier("Win32_BaseBoard", "SerialNumber");
                string combinedId = cpuId + motherboardId;

                // Hash the combined string to create a fixed-length, anonymous ID
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedId));
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        builder.Append(hashBytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
            catch
            {
                // Fallback in case WMI fails
                return "CouldNotGenerateHWID";
            }
        }

        private static string GetIdentifier(string wmiClass, string wmiProperty)
        {
            string result = "";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM " + wmiClass);
                foreach (ManagementObject mo in searcher.Get())
                {
                    if (mo[wmiProperty] != null)
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                }
            }
            catch
            {
                // Ignore errors, result will be empty
            }
            return result;
        }
    }
}
