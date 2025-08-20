using System;
using System.Windows.Forms;

namespace FlowOptimizer
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Modules.Auth.CheckHwid())
            {
                Application.Run(new Form1());
            }
            else
            {
                using (LoginForm loginForm = new LoginForm())
                {
                    // Show the login form as a dialog.
                    if (loginForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        // If login was successful, run the main form.
                        Application.Run(new Form1());
                    }
                    // If the user closes the login form or fails to log in, the application will exit.
                }
            }
        }
    }
}
