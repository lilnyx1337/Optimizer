using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FlowOptimizer.Modules
{
    public static class Auth
    {
        // In a real application, this would be more secure.
        private const string validKey = "FLOW-OPTIMIZER-KEY-2025";
        private static readonly string authFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "FlowOptimizer",
            "auth.dat");

        public static bool ValidateKey(string key)
        {
            return key == validKey;
        }

        public static void SaveHwid(string hwid)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(authFilePath));
                // In a real app, you'd encrypt this. For this example, we'll store it hashed.
                string hashedHwid = HashString(hwid);
                File.WriteAllText(authFilePath, hashedHwid);
            }
            catch (Exception) { /* Handle potential IO errors */ }
        }

        public static string GetSavedHwid()
        {
            try
            {
                if (File.Exists(authFilePath))
                {
                    return File.ReadAllText(authFilePath);
                }
            }
            catch (Exception) { /* Handle potential IO errors */ }
            return null;
        }

        public static bool CheckHwid()
        {
            string savedHwid = GetSavedHwid();
            if (savedHwid == null) return false;

            string currentHwid = HWID.Generate();
            string currentHwidHashed = HashString(currentHwid);

            return savedHwid == currentHwidHashed;
        }

        private static string HashString(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
