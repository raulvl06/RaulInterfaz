using System.Windows;

namespace MiProyecto
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        // =====================================
        // TIENDA
        // =====================================

        private void Tienda_Click(object sender, RoutedEventArgs e)
        {
            Biblioteca.Visibility = Visibility.Collapsed;
            Tienda.Visibility = Visibility.Visible;
            Comunidad.Visibility = Visibility.Collapsed;
            Soporte.Visibility = Visibility.Collapsed;
            Perfil.Visibility = Visibility.Collapsed;
        }


        // =====================================
        // BIBLIOTECA
        // =====================================

        private void Biblioteca_Click(object sender, RoutedEventArgs e)
        {
            Biblioteca.Visibility = Visibility.Visible;
            Tienda.Visibility = Visibility.Collapsed;
            Comunidad.Visibility = Visibility.Collapsed;
            Soporte.Visibility = Visibility.Collapsed;
            Perfil.Visibility = Visibility.Collapsed;
        }


        // =====================================
        // COMUNIDAD
        // =====================================

        private void Comunidad_Click(object sender, RoutedEventArgs e)
        {
            Biblioteca.Visibility = Visibility.Collapsed;
            Tienda.Visibility = Visibility.Collapsed;
            Comunidad.Visibility = Visibility.Visible;
            Soporte.Visibility = Visibility.Collapsed;
            Perfil.Visibility = Visibility.Collapsed;
        }


        // =====================================
        // SOPORTE
        // =====================================

        private void Soporte_Click(object sender, RoutedEventArgs e)
        {
            Biblioteca.Visibility = Visibility.Collapsed;
            Tienda.Visibility = Visibility.Collapsed;
            Comunidad.Visibility = Visibility.Collapsed;
            Soporte.Visibility = Visibility.Visible;
            Perfil.Visibility = Visibility.Collapsed;
        }


        // =====================================
        // PERFIL
        // =====================================

        private void Perfil_Click(object sender, RoutedEventArgs e)
        {
            Biblioteca.Visibility = Visibility.Collapsed;
            Tienda.Visibility = Visibility.Collapsed;
            Comunidad.Visibility = Visibility.Collapsed;
            Soporte.Visibility = Visibility.Collapsed;
            Perfil.Visibility = Visibility.Visible;
        }


        // =====================================
        // JUEGOS DE LA BIBLIOTECA
        // =====================================

        private void Juego1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abriendo Minecraft");
        }


        private void Juego2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abriendo FC 27");
        }


        private void Juego3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abriendo Overwatch");
        }


        // =====================================
        // JUEGOS DE LA TIENDA
        // =====================================

        private void ComprarDiablo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Comprando Diablo IV");
        }


        private void ComprarFortnite_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Comprando Fortnite");
        }


        private void ComprarCallOfDuty_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Comprando Call of Duty");
        }


        // =====================================
        // COMUNIDAD
        // =====================================

        private void Foro_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abriendo Foro");
        }


        private void Amigos_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abriendo Amigos");
        }


        // =====================================
        // SOPORTE
        // =====================================

        private void Ayuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abriendo Ayuda");
        }


        private void Contactar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abriendo Contactar");
        }


        // =====================================
        // PERFIL
        // =====================================

        private void MiCuenta_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abriendo Mi cuenta");
        }


        // =====================================
        // SALIR
        // =====================================

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
