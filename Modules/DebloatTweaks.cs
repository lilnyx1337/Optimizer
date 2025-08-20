using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FlowOptimizer.Modules
{
    public static class DebloatTweaks
    {
        private static readonly List<string> appsToRemove = new List<string>
        {
            "Microsoft.549981C3F5F10",           // Cortana
            "Microsoft.BingNews",
            "Microsoft.BingWeather",
            "Microsoft.GetHelp",
            "Microsoft.Getstarted",
            "Microsoft.Microsoft3DViewer",
            "Microsoft.MicrosoftOfficeHub",
            "Microsoft.MicrosoftSolitaireCollection",
            "Microsoft.MicrosoftStickyNotes",
            "Microsoft.MixedReality.Portal",
            "Microsoft.OneConnect",               // Print 3D
            "Microsoft.People",
            "Microsoft.SkypeApp",
            "Microsoft.WindowsAlarms",
            "Microsoft.WindowsCamera",
            "Microsoft.WindowsFeedbackHub",
            "Microsoft.WindowsMaps",
            "Microsoft.WindowsSoundRecorder",
            "Microsoft.YourPhone",
            "Microsoft.ZuneMusic",                // Groove Music
            "Microsoft.ZuneVideo"
        };

        public static void Apply()
        {
            var confirmResult = MessageBox.Show(
                "This will remove several built-in Windows apps for the current user. This action is not easily reversible. Are you sure you want to continue?",
                "Confirm Debloat",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                foreach (var appName in appsToRemove)
                {
                    ExecutePowerShellCommand($"Get-AppxPackage *{appName}* | Remove-AppxPackage");
                    ExecutePowerShellCommand($"Get-AppxProvisionedPackage -Online | Where-Object {{ $_.PackageName -like '*{appName}*' }} | Remove-AppxProvisionedPackage -Online");
                }
                 MessageBox.Show("Debloat process completed. Some changes may require a restart to take full effect.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // No restore functionality for debloating as it's complex.
        // Apps must be reinstalled from the Windows Store.
        public static void Restore()
        {
             MessageBox.Show("Automatic restore for debloated apps is not supported. Please use the Microsoft Store to reinstall any needed applications.", "Restore Not Supported", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void ExecutePowerShellCommand(string command)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                }
            };
            process.Start();
            process.WaitForExit();
        }
    }
}
