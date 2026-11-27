using di.proyecto.clase._2026.Servicios;
using di.proyecto.clase_2026.Vista.Dialogos;
using MahApps.Metro.Controls;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace di.proyecto.clase._2026
{
    
    public partial class MainWindow : MetroWindow
    {
        private MainWindow _mainWindow;
        private DialogoModeloArticulo _dialogoModeloArticulo;
        private readonly UsuarioSesion _usuarioSesion;

        public MainWindow(DialogoModeloArticulo dialogoModeloArticulo, UsuarioSesion usuarioSesion)
        {
            InitializeComponent();
            _dialogoModeloArticulo = dialogoModeloArticulo;
            _usuarioSesion = usuarioSesion;
        }

        private void btnAddModeloArticulo_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = _mainWindow;
            _dialogoModeloArticulo.Show();
            Close();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Actualizamos el nombre del usuario en la interfaz de usuario para ver quién ha iniciado sesión
            tbUsuarioLogin.Text = _usuarioSesion.UsuarioActual?.Nombre ?? "Usuario no identificado";
        }
    }
}