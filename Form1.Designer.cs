namespace FlowOptimizer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputGroupBox = new System.Windows.Forms.GroupBox();
            this.applyInputTweaksButton = new System.Windows.Forms.Button();
            this.restoreInputTweaksButton = new System.Windows.Forms.Button();

            this.networkGroupBox = new System.Windows.Forms.GroupBox();
            this.applyNetworkTweaksButton = new System.Windows.Forms.Button();
            this.restoreNetworkTweaksButton = new System.Windows.Forms.Button();

            this.powerGroupBox = new System.Windows.Forms.GroupBox();
            this.applyPowerTweaksButton = new System.Windows.Forms.Button();
            this.restorePowerTweaksButton = new System.Windows.Forms.Button();

            this.serviceGroupBox = new System.Windows.Forms.GroupBox();
            this.applyServiceTweaksButton = new System.Windows.Forms.Button();
            this.restoreServiceTweaksButton = new System.Windows.Forms.Button();

            this.debloatGroupBox = new System.Windows.Forms.GroupBox();
            this.applyDebloatButton = new System.Windows.Forms.Button();
            this.restoreDebloatButton = new System.Windows.Forms.Button();

            this.cleanupGroupBox = new System.Windows.Forms.GroupBox();
            this.applyCleanupButton = new System.Windows.Forms.Button();

            this.inputGroupBox.SuspendLayout();
            this.networkGroupBox.SuspendLayout();
            this.powerGroupBox.SuspendLayout();
            this.serviceGroupBox.SuspendLayout();
            this.debloatGroupBox.SuspendLayout();
            this.cleanupGroupBox.SuspendLayout();
            this.SuspendLayout();

            //
            // inputGroupBox
            //
            this.inputGroupBox.Controls.Add(this.applyInputTweaksButton);
            this.inputGroupBox.Controls.Add(this.restoreInputTweaksButton);
            this.inputGroupBox.Location = new System.Drawing.Point(12, 12);
            this.inputGroupBox.Name = "inputGroupBox";
            this.inputGroupBox.Size = new System.Drawing.Size(330, 60);
            this.inputGroupBox.TabIndex = 0;
            this.inputGroupBox.TabStop = false;
            this.inputGroupBox.Text = "Input Tweaks";
            //
            // applyInputTweaksButton
            //
            this.applyInputTweaksButton.Location = new System.Drawing.Point(6, 21);
            this.applyInputTweaksButton.Name = "applyInputTweaksButton";
            this.applyInputTweaksButton.Size = new System.Drawing.Size(150, 23);
            this.applyInputTweaksButton.TabIndex = 0;
            this.applyInputTweaksButton.Text = "Apply Input Tweaks";
            this.applyInputTweaksButton.UseVisualStyleBackColor = true;
            this.applyInputTweaksButton.Click += new System.EventHandler(this.applyInputTweaksButton_Click);
            //
            // restoreInputTweaksButton
            //
            this.restoreInputTweaksButton.Location = new System.Drawing.Point(162, 21);
            this.restoreInputTweaksButton.Name = "restoreInputTweaksButton";
            this.restoreInputTweaksButton.Size = new System.Drawing.Size(150, 23);
            this.restoreInputTweaksButton.TabIndex = 1;
            this.restoreInputTweaksButton.Text = "Restore Input Tweaks";
            this.restoreInputTweaksButton.UseVisualStyleBackColor = true;
            this.restoreInputTweaksButton.Click += new System.EventHandler(this.restoreInputTweaksButton_Click);

            //
            // networkGroupBox
            //
            this.networkGroupBox.Controls.Add(this.applyNetworkTweaksButton);
            this.networkGroupBox.Controls.Add(this.restoreNetworkTweaksButton);
            this.networkGroupBox.Location = new System.Drawing.Point(12, 78);
            this.networkGroupBox.Name = "networkGroupBox";
            this.networkGroupBox.Size = new System.Drawing.Size(330, 60);
            this.networkGroupBox.TabIndex = 1;
            this.networkGroupBox.TabStop = false;
            this.networkGroupBox.Text = "Network Tweaks";
            //
            // applyNetworkTweaksButton
            //
            this.applyNetworkTweaksButton.Location = new System.Drawing.Point(6, 21);
            this.applyNetworkTweaksButton.Name = "applyNetworkTweaksButton";
            this.applyNetworkTweaksButton.Size = new System.Drawing.Size(150, 23);
            this.applyNetworkTweaksButton.TabIndex = 2;
            this.applyNetworkTweaksButton.Text = "Apply Network Tweaks";
            this.applyNetworkTweaksButton.UseVisualStyleBackColor = true;
            this.applyNetworkTweaksButton.Click += new System.EventHandler(this.applyNetworkTweaksButton_Click);
            //
            // restoreNetworkTweaksButton
            //
            this.restoreNetworkTweaksButton.Location = new System.Drawing.Point(162, 21);
            this.restoreNetworkTweaksButton.Name = "restoreNetworkTweaksButton";
            this.restoreNetworkTweaksButton.Size = new System.Drawing.Size(150, 23);
            this.restoreNetworkTweaksButton.TabIndex = 3;
            this.restoreNetworkTweaksButton.Text = "Restore Network Tweaks";
            this.restoreNetworkTweaksButton.UseVisualStyleBackColor = true;
            this.restoreNetworkTweaksButton.Click += new System.EventHandler(this.restoreNetworkTweaksButton_Click);

            //
            // powerGroupBox
            //
            this.powerGroupBox.Controls.Add(this.applyPowerTweaksButton);
            this.powerGroupBox.Controls.Add(this.restorePowerTweaksButton);
            this.powerGroupBox.Location = new System.Drawing.Point(12, 144);
            this.powerGroupBox.Name = "powerGroupBox";
            this.powerGroupBox.Size = new System.Drawing.Size(330, 60);
            this.powerGroupBox.TabIndex = 2;
            this.powerGroupBox.TabStop = false;
            this.powerGroupBox.Text = "Power Tweaks";
            //
            // applyPowerTweaksButton
            //
            this.applyPowerTweaksButton.Location = new System.Drawing.Point(6, 21);
            this.applyPowerTweaksButton.Name = "applyPowerTweaksButton";
            this.applyPowerTweaksButton.Size = new System.Drawing.Size(150, 23);
            this.applyPowerTweaksButton.TabIndex = 4;
            this.applyPowerTweaksButton.Text = "Apply Power Tweaks";
            this.applyPowerTweaksButton.UseVisualStyleBackColor = true;
            this.applyPowerTweaksButton.Click += new System.EventHandler(this.applyPowerTweaksButton_Click);
            //
            // restorePowerTweaksButton
            //
            this.restorePowerTweaksButton.Location = new System.Drawing.Point(162, 21);
            this.restorePowerTweaksButton.Name = "restorePowerTweaksButton";
            this.restorePowerTweaksButton.Size = new System.Drawing.Size(150, 23);
            this.restorePowerTweaksButton.TabIndex = 5;
            this.restorePowerTweaksButton.Text = "Restore Power Tweaks";
            this.restorePowerTweaksButton.UseVisualStyleBackColor = true;
            this.restorePowerTweaksButton.Click += new System.EventHandler(this.restorePowerTweaksButton_Click);

            //
            // serviceGroupBox
            //
            this.serviceGroupBox.Controls.Add(this.applyServiceTweaksButton);
            this.serviceGroupBox.Controls.Add(this.restoreServiceTweaksButton);
            this.serviceGroupBox.Location = new System.Drawing.Point(12, 210);
            this.serviceGroupBox.Name = "serviceGroupBox";
            this.serviceGroupBox.Size = new System.Drawing.Size(330, 60);
            this.serviceGroupBox.TabIndex = 3;
            this.serviceGroupBox.TabStop = false;
            this.serviceGroupBox.Text = "Service & Telemetry Tweaks";
            //
            // applyServiceTweaksButton
            //
            this.applyServiceTweaksButton.Location = new System.Drawing.Point(6, 21);
            this.applyServiceTweaksButton.Name = "applyServiceTweaksButton";
            this.applyServiceTweaksButton.Size = new System.Drawing.Size(150, 23);
            this.applyServiceTweaksButton.TabIndex = 6;
            this.applyServiceTweaksButton.Text = "Apply Service Tweaks";
            this.applyServiceTweaksButton.UseVisualStyleBackColor = true;
            this.applyServiceTweaksButton.Click += new System.EventHandler(this.applyServiceTweaksButton_Click);
            //
            // restoreServiceTweaksButton
            //
            this.restoreServiceTweaksButton.Location = new System.Drawing.Point(162, 21);
            this.restoreServiceTweaksButton.Name = "restoreServiceTweaksButton";
            this.restoreServiceTweaksButton.Size = new System.Drawing.Size(150, 23);
            this.restoreServiceTweaksButton.TabIndex = 7;
            this.restoreServiceTweaksButton.Text = "Restore Service Tweaks";
            this.restoreServiceTweaksButton.UseVisualStyleBackColor = true;
            this.restoreServiceTweaksButton.Click += new System.EventHandler(this.restoreServiceTweaksButton_Click);

            //
            // debloatGroupBox
            //
            this.debloatGroupBox.Controls.Add(this.applyDebloatButton);
            this.debloatGroupBox.Controls.Add(this.restoreDebloatButton);
            this.debloatGroupBox.Location = new System.Drawing.Point(12, 276);
            this.debloatGroupBox.Name = "debloatGroupBox";
            this.debloatGroupBox.Size = new System.Drawing.Size(330, 60);
            this.debloatGroupBox.TabIndex = 4;
            this.debloatGroupBox.TabStop = false;
            this.debloatGroupBox.Text = "Windows Debloater";
            //
            // applyDebloatButton
            //
            this.applyDebloatButton.Location = new System.Drawing.Point(6, 21);
            this.applyDebloatButton.Name = "applyDebloatButton";
            this.applyDebloatButton.Size = new System.Drawing.Size(150, 23);
            this.applyDebloatButton.TabIndex = 8;
            this.applyDebloatButton.Text = "Apply Debloat";
            this.applyDebloatButton.UseVisualStyleBackColor = true;
            this.applyDebloatButton.Click += new System.EventHandler(this.applyDebloatButton_Click);
            //
            // restoreDebloatButton
            //
            this.restoreDebloatButton.Location = new System.Drawing.Point(162, 21);
            this.restoreDebloatButton.Name = "restoreDebloatButton";
            this.restoreDebloatButton.Size = new System.Drawing.Size(150, 23);
            this.restoreDebloatButton.TabIndex = 9;
            this.restoreDebloatButton.Text = "Restore Debloat";
            this.restoreDebloatButton.UseVisualStyleBackColor = true;
            this.restoreDebloatButton.Click += new System.EventHandler(this.restoreDebloatButton_Click);

            //
            // cleanupGroupBox
            //
            this.cleanupGroupBox.Controls.Add(this.applyCleanupButton);
            this.cleanupGroupBox.Location = new System.Drawing.Point(12, 342);
            this.cleanupGroupBox.Name = "cleanupGroupBox";
            this.cleanupGroupBox.Size = new System.Drawing.Size(330, 60);
            this.cleanupGroupBox.TabIndex = 5;
            this.cleanupGroupBox.TabStop = false;
            this.cleanupGroupBox.Text = "System Cleanup";
            //
            // applyCleanupButton
            //
            this.applyCleanupButton.Location = new System.Drawing.Point(6, 21);
            this.applyCleanupButton.Name = "applyCleanupButton";
            this.applyCleanupButton.Size = new System.Drawing.Size(150, 23);
            this.applyCleanupButton.TabIndex = 10;
            this.applyCleanupButton.Text = "Apply System Cleanup";
            this.applyCleanupButton.UseVisualStyleBackColor = true;
            this.applyCleanupButton.Click += new System.EventHandler(this.applyCleanupButton_Click);

            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 411);
            this.Controls.Add(this.inputGroupBox);
            this.Controls.Add(this.networkGroupBox);
            this.Controls.Add(this.powerGroupBox);
            this.Controls.Add(this.serviceGroupBox);
            this.Controls.Add(this.debloatGroupBox);
            this.Controls.Add(this.cleanupGroupBox);
            this.Name = "Form1";
            this.Text = "FlowOptimizer";
            this.inputGroupBox.ResumeLayout(false);
            this.networkGroupBox.ResumeLayout(false);
            this.powerGroupBox.ResumeLayout(false);
            this.serviceGroupBox.ResumeLayout(false);
            this.debloatGroupBox.ResumeLayout(false);
            this.cleanupGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox inputGroupBox;
        private System.Windows.Forms.Button applyInputTweaksButton;
        private System.Windows.Forms.Button restoreInputTweaksButton;

        private System.Windows.Forms.GroupBox networkGroupBox;
        private System.Windows.Forms.Button applyNetworkTweaksButton;
        private System.Windows.Forms.Button restoreNetworkTweaksButton;

        private System.Windows.Forms.GroupBox powerGroupBox;
        private System.Windows.Forms.Button applyPowerTweaksButton;
        private System.Windows.Forms.Button restorePowerTweaksButton;

        private System.Windows.Forms.GroupBox serviceGroupBox;
        private System.Windows.Forms.Button applyServiceTweaksButton;
        private System.Windows.Forms.Button restoreServiceTweaksButton;

        private System.Windows.Forms.GroupBox debloatGroupBox;
        private System.Windows.Forms.Button applyDebloatButton;
        private System.Windows.Forms.Button restoreDebloatButton;

        private System.Windows.Forms.GroupBox cleanupGroupBox;
        private System.Windows.Forms.Button applyCleanupButton;
    }
}
