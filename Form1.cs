using FlowOptimizer.Modules;
using System;
using System.Windows.Forms;

namespace FlowOptimizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void applyInputTweaksButton_Click(object sender, EventArgs e)
        {
            try
            {
                InputTweaks.Apply();
                MessageBox.Show("Input tweaks applied successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void restoreInputTweaksButton_Click(object sender, EventArgs e)
        {
            try
            {
                InputTweaks.Restore();
                MessageBox.Show("Input tweaks restored successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void applyNetworkTweaksButton_Click(object sender, EventArgs e)
        {
            try
            {
                NetworkTweaks.Apply();
                MessageBox.Show("Network tweaks applied successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void restoreNetworkTweaksButton_Click(object sender, EventArgs e)
        {
            try
            {
                NetworkTweaks.Restore();
                MessageBox.Show("Network tweaks restored successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void applyPowerTweaksButton_Click(object sender, EventArgs e)
        {
            try
            {
                PowerTweaks.Apply();
                MessageBox.Show("Power tweaks applied successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void restorePowerTweaksButton_Click(object sender, EventArgs e)
        {
            try
            {
                PowerTweaks.Restore();
                MessageBox.Show("Power tweaks restored successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void applyServiceTweaksButton_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceTweaks.Apply();
                MessageBox.Show("Service tweaks applied successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void restoreServiceTweaksButton_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceTweaks.Restore();
                MessageBox.Show("Service tweaks restored successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void applyDebloatButton_Click(object sender, EventArgs e)
        {
            try
            {
                DebloatTweaks.Apply();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void restoreDebloatButton_Click(object sender, EventArgs e)
        {
            try
            {
                DebloatTweaks.Restore();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void applyCleanupButton_Click(object sender, EventArgs e)
        {
            try
            {
                CleanupTweaks.Apply();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
