using System.Windows;

namespace MiProyecto
{
    public partial class MainWindow : Window
    {
        private string usuarioActual;

        public MainWindow() : this("Usuario") { }

        public MainWindow(string nombreUsuario)
        {
            InitializeComponent();
            usuarioActual = nombreUsuario;
            BtnPerfil.Content = usuarioActual;
        }

        private void Tienda_Click(object sender, RoutedEventArgs e)
        {
            Biblioteca.Visibility = Visibility.Collapsed;
            Tienda.Visibility = Visibility.Visible;
            Comunidad.Visibility = Visibility.Collapsed;
            Soporte.Visibility = Visibility.Collapsed;
            Perfil.Visibility = Visibility.Collapsed;
        }

        private void Biblioteca_Click(object sender, RoutedEventArgs e)
        {
            Biblioteca.Visibility = Visibility.Visible;
            Tienda.Visibility = Visibility.Collapsed;
            Comunidad.Visibility = Visibility.Collapsed;
            Soporte.Visibility = Visibility.Collapsed;
            Perfil.Visibility = Visibility.Collapsed;
        }

        private void Comunidad_Click(object sender, RoutedEventArgs e)
        {
            Biblioteca.Visibility = Visibility.Collapsed;
            Tienda.Visibility = Visibility.Collapsed;
            Comunidad.Visibility = Visibility.Visible;
            Soporte.Visibility = Visibility.Collapsed;
            Perfil.Visibility = Visibility.Collapsed;
        }

        private void Soporte_Click(object sender, RoutedEventArgs e)
        {
            Biblioteca.Visibility = Visibility.Collapsed;
            Tienda.Visibility = Visibility.Collapsed;
            Comunidad.Visibility = Visibility.Collapsed;
            Soporte.Visibility = Visibility.Visible;
            Perfil.Visibility = Visibility.Collapsed;
        }

        private void Perfil_Click(object sender, RoutedEventArgs e)
        {
            Biblioteca.Visibility = Visibility.Collapsed;
            Tienda.Visibility = Visibility.Collapsed;
            Comunidad.Visibility = Visibility.Collapsed;
            Soporte.Visibility = Visibility.Collapsed;
            Perfil.Visibility = Visibility.Visible;
        }

        private void Juego1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abriendo Minecraft", "GameStation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Juego2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abriendo FC 27", "GameStation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Juego3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abriendo Overwatch", "GameStation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ComprarDiablo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Comprando Diablo IV", "GameStation Store", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ComprarFortnite_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Comprando Fortnite", "GameStation Store", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ComprarCallOfDuty_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Comprando Call of Duty", "GameStation Store", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Foro_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abriendo Foro", "Comunidad", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Amigos_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abriendo Amigos", "Comunidad", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Ayuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abriendo Ayuda", "Soporte", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Contactar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abriendo Contactar", "Soporte", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MiCuenta_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Cuenta activa de: {usuarioActual}", "Perfil", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            Close();
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}