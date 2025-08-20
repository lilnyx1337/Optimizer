using System;
using System.Windows.Forms;

namespace FlowOptimizer
{
    public partial class LoginForm : Form
    {
        public bool IsAuthenticated { get; private set; } = false;

        public LoginForm()
        {
            InitializeComponent();
        }

        // 1. Se convierte el método en asíncrono (async void)
        private async void loginButton_Click(object sender, EventArgs e)
        {
            string key = this.keyTextBox.Text;

            // Desactivar el botón para evitar múltiples clics mientras se verifica
            loginButton.Enabled = false;
            loginButton.Text = "Verificando...";

            // 2. Se llama al nuevo KeyVerifier que contacta con la API
            var resultado = await KeyVerifier.VerifyKeyAsync(key);

            // 3. Se comprueba el resultado de la API
            if (resultado.Status == "success")
            {
                // Si la clave es válida, se cierra el formulario
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // 4. Se muestra el mensaje de error DETALLADO que viene de la API
                MessageBox.Show(resultado.Message, "Fallo de Activación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Volver a activar el botón
            loginButton.Enabled = true;
            loginButton.Text = "Login";
        }
    }
}