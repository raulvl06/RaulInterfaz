using System.Collections.Generic;
using System.Windows;

namespace MiProyecto
{
    public partial class LoginWindow : Window
    {
        private static Dictionary<string, int> intentosFallidos = new Dictionary<string, int>();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Password;

            var usuariosValidos = new Dictionary<string, string>
            {
                { "admin", "1234" },
                { "raul", "password123" },
                { "invitado", "0000" }
            };

            if (intentosFallidos.ContainsKey(usuario) && intentosFallidos[usuario] >= 3)
            {
                txtError.Text = "Cuenta bloqueada temporalmente por 3 intentos fallidos.";
                BorderError.Visibility = Visibility.Visible;
                return;
            }

            if (!usuariosValidos.ContainsKey(usuario))
            {
                txtError.Text = "El usuario introducido no existe.";
                BorderError.Visibility = Visibility.Visible;
                return;
            }

            if (usuariosValidos[usuario] != password)
            {
                if (!intentosFallidos.ContainsKey(usuario))
                {
                    intentosFallidos[usuario] = 0;
                }
                intentosFallidos[usuario]++;

                int intentosRestantes = 3 - intentosFallidos[usuario];

                if (intentosRestantes > 0)
                {
                    txtError.Text = $"Contraseña incorrecta. Te quedan {intentosRestantes} intentos.";
                }
                else
                {
                    txtError.Text = "Cuenta bloqueada por superar los 3 intentos.";
                }

                BorderError.Visibility = Visibility.Visible;
                return;
            }

            intentosFallidos[usuario] = 0;
            MainWindow principal = new MainWindow(usuario);
            principal.Show();
            this.Close();
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}