using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace ProyectoRaul
{
    public partial class LoginWindow : Window
    {
        private static Dictionary<string, int> intentosFallidos = new Dictionary<string, int>();
        private static Dictionary<string, DateTime> tiempoBloqueo = new Dictionary<string, DateTime>();
        private DispatcherTimer timerVerificacion;

        public LoginWindow()
        {
            InitializeComponent();

            // Timer para actualizar la interfaz o comprobar si ya pasó el tiempo de bloqueo
            timerVerificacion = new DispatcherTimer();
            timerVerificacion.Interval = TimeSpan.FromSeconds(1);
            timerVerificacion.Tick += TimerVerificacion_Tick;
            timerVerificacion.Start();
        }

        private void TimerVerificacion_Tick(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            if (!string.IsNullOrEmpty(usuario) && tiempoBloqueo.ContainsKey(usuario))
            {
                var tiempoRestante = 60 - (DateTime.Now - tiempoBloqueo[usuario]).TotalSeconds;
                if (tiempoRestante <= 0)
                {
                    // Expiró el bloqueo
                    tiempoBloqueo.Remove(usuario);
                    intentosFallidos[usuario] = 0;
                    BorderError.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Password;

            // Validación para cuando no se rellenan los campos (TC 04)
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                txtError.Text = "Introduzca datos";
                BorderError.Visibility = Visibility.Visible;
                return;
            }

            var usuariosValidos = new Dictionary<string, string>
            {
                { "admin", "1234" },
                { "raul", "password123" },
                { "invitado", "0000" }
            };

            // Comprobar si el usuario está bloqueado y si aún no han pasado los 60 segundos
            if (tiempoBloqueo.ContainsKey(usuario))
            {
                double segundosPasados = (DateTime.Now - tiempoBloqueo[usuario]).TotalSeconds;
                if (segundosPasados < 60)
                {
                    int segundosRestantes = (int)(60 - segundosPasados);
                    txtError.Text = $"Perfil bloqueado. Inténtelo en {segundosRestantes} segundos.";
                    BorderError.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    // Limpiar bloqueo tras transcurrir los 60 segundos
                    tiempoBloqueo.Remove(usuario);
                    intentosFallidos[usuario] = 0;
                }
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
                    // Registrar el momento exacto del bloqueo
                    tiempoBloqueo[usuario] = DateTime.Now;
                    txtError.Text = "Cuenta bloqueada durante 60 segundos por 3 intentos fallidos.";
                }

                BorderError.Visibility = Visibility.Visible;
                return;
            }

            // Inicio exitoso
            intentosFallidos[usuario] = 0;
            tiempoBloqueo.Remove(usuario);
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