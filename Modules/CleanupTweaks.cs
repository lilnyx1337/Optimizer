using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FlowOptimizer.Modules
{
    public static class CleanupTweaks
    {
        public static void Apply()
        {
            var confirmResult = MessageBox.Show(
                "This will delete temporary files and clear system caches. This action cannot be undone. Are you sure you want to continue?",
                "Confirm System Cleanup",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Flush DNS
                ExecuteCommand("ipconfig", "/flushdns");

                // Clean Temp Folders
                CleanDirectory(Path.GetTempPath()); // User Temp
                CleanDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Temp")); // Windows Temp

                MessageBox.Show("System cleanup completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void Restore()
        {
            MessageBox.Show("The cleanup operation cannot be restored.", "Restore Not Applicable", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void CleanDirectory(string path)
        {
            if (!Directory.Exists(path)) return;

            DirectoryInfo dirInfo = new DirectoryInfo(path);

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                try
                {
                    file.Delete();
                }
                catch (Exception) { /* Ignore files in use or permission errors */ }
            }

            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                try
                {
                    dir.Delete(true);
                }
                catch (Exception) { /* Ignore directories in use or permission errors */ }
            }
        }

        private static void ExecuteCommand(string fileName, string arguments)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    Verb = "runas" // Request administrator privileges
                }
            };
            try
            {
                process.Start();
                process.WaitForExit();
            }
            catch (Exception)
            {
                // Handle case where user denies admin privileges
            }
        }
    }
}
