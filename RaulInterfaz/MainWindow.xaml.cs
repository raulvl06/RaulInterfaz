using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProyectoRaul
{
    public partial class MainWindow : Window
    {
        private readonly string usuarioActual;

        public MainWindow() : this("Usuario") { }

        public MainWindow(string nombreUsuario)
        {
            InitializeComponent();
            usuarioActual = nombreUsuario;
            BtnPerfil.Content = usuarioActual;
            ActualizarColoresMenu(BtnNavBiblioteca);
        }

        private void ActualizarColoresMenu(Button botonActivo)
        {
            var colorInactivo = (Brush)new BrushConverter().ConvertFrom("#c6d4df");
            var colorActivo = (Brush)new BrushConverter().ConvertFrom("#66c0f4");

            BtnNavTienda.Foreground = colorInactivo;
            BtnNavBiblioteca.Foreground = colorInactivo;
            BtnNavComunidad.Foreground = colorInactivo;
            BtnNavSoporte.Foreground = colorInactivo;
            BtnPerfil.Foreground = colorInactivo;

            if (botonActivo != null)
            {
                botonActivo.Foreground = colorActivo;
            }
        }

        private void CambiarSeccion(UIElement seccionActiva, Button botonMenu)
        {
            Biblioteca.Visibility = Visibility.Collapsed;
            Tienda.Visibility = Visibility.Collapsed;
            Comunidad.Visibility = Visibility.Collapsed;
            Soporte.Visibility = Visibility.Collapsed;
            Perfil.Visibility = Visibility.Collapsed;

            seccionActiva.Visibility = Visibility.Visible;
            ActualizarColoresMenu(botonMenu);
        }

        private void Tienda_Click(object sender, RoutedEventArgs e) => CambiarSeccion(Tienda, BtnNavTienda);
        private void Biblioteca_Click(object sender, RoutedEventArgs e) => CambiarSeccion(Biblioteca, BtnNavBiblioteca);
        private void Comunidad_Click(object sender, RoutedEventArgs e) => CambiarSeccion(Comunidad, BtnNavComunidad);
        private void Soporte_Click(object sender, RoutedEventArgs e) => CambiarSeccion(Soporte, BtnNavSoporte);
        private void Perfil_Click(object sender, RoutedEventArgs e) => CambiarSeccion(Perfil, BtnPerfil);

        private void MostrarDetalleJuego(string juego)
        {
            TxtTituloJuegoDetalle.Text = juego.ToUpper();

            try
            {
                // Mapeo seguro y limpio optimizado por nombre de archivo
                string archivoImg = juego switch
                {
                    "Minecraft" => "Minecraft.png",
                    "FC 27" => "FC27.png",
                    "Grand Theft Auto V" => "GTAV.png",
                    "Cyberpunk 2077" => "Cyberpunk.png",
                    "Counter-Strike 2" => "CS2.png",
                    _ => "Minecraft.png"
                };

                ImgBannerJuego.Source = new BitmapImage(new Uri($"Imagenes/Banner/{archivoImg}", UriKind.Relative));
            }
            catch
            {
                // Fallback silencioso ante errores de recursos
            }

            PanelListaJuegos.Visibility = Visibility.Collapsed;
            PanelDetalleJuego.Visibility = Visibility.Visible;
        }

        private void TarjetaJuego_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement { Tag: string juego })
            {
                MostrarDetalleJuego(juego);
            }
        }

        private void AbrirDetalleJuego_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement { Tag: string juego })
            {
                MostrarDetalleJuego(juego);
            }
        }

        private void VolverBiblioteca_Click(object sender, RoutedEventArgs e)
        {
            PanelDetalleJuego.Visibility = Visibility.Collapsed;
            PanelListaJuegos.Visibility = Visibility.Visible;
        }

        private void EjecutarJuegoDetalle_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Abriendo {TxtTituloJuegoDetalle.Text}", "GameStation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Métodos de Tienda resumidos
        private void ComprarMinecraft_Click(object sender, RoutedEventArgs e) => NotificarTienda("Minecraft", "29,99€");
        private void ComprarFC27_Click(object sender, RoutedEventArgs e) => NotificarTienda("EA Sports FC 27", "69,99€");
        private void ComprarOverwatch_Click(object sender, RoutedEventArgs e) => NotificarTienda("Overwatch", "Gratis");
        private void ComprarGTA5_Click(object sender, RoutedEventArgs e) => NotificarTienda("Grand Theft Auto V", "29,99€");
        private void ComprarGTA6_Click(object sender, RoutedEventArgs e) => NotificarTienda("Grand Theft Auto VI", "79,99€");
        private void ComprarCyberpunk_Click(object sender, RoutedEventArgs e) => NotificarTienda("Cyberpunk 2077", "59,99€");

        private void NotificarTienda(string juego, string precio)
        {
            MessageBox.Show($"Adquiriendo {juego} por {precio}", "GameStation Store", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Comunidad y Soporte
        private void Foro_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Abriendo Foros de Discusión", "Comunidad", MessageBoxButton.OK, MessageBoxImage.Information);
        private void Amigos_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Abriendo Lista de Amigos", "Comunidad", MessageBoxButton.OK, MessageBoxImage.Information);
        private void Ayuda_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Abriendo Preguntas Frecuentes", "Soporte", MessageBoxButton.OK, MessageBoxImage.Information);
        private void Contactar_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Abriendo formulario de contacto", "Soporte", MessageBoxButton.OK, MessageBoxImage.Information);

        // Perfil y Sesión
        private void MiCuenta_Click(object sender, RoutedEventArgs e) => MessageBox.Show($"Cuenta activa de: {usuarioActual}", "Perfil", MessageBoxButton.OK, MessageBoxImage.Information);

        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }

        private void Salir_Click(object sender, RoutedEventArgs e) => Close();
    }
}