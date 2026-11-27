using di.proyecto.clase._2026;
using di.proyecto.clase._2026.Modelos;
using di.proyecto.clase._2026.Servicios;
using di.proyecto.clase._2026.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace di.proyecto.clase_2026.Vista.Dialogos
{
   
    public partial class Login : Window
    {

        private MainWindow _mainWindow;
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly UsuarioSesion _usuarioSesion;
        
        public Login(MainWindow mainWindow, IUsuarioServicio usuarioServicio, UsuarioSesion usuarioSesion)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _usuarioServicio = usuarioServicio;
            _usuarioSesion = usuarioSesion;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text;
            string password = passClave.Password;
            //Guardar el usuario que inicie sesion en una variable para poder usarlo en la ventana principal
            Usuario usuario;

            if (string.IsNullOrEmpty(username)
           || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Error de inicio de sesión",
                     "Por favor, ingrese un nombre de usuario y una contraseña.");
            }
            else
            {
                usuario = await _usuarioServicio.LoginAsync(username, password); //Asociar el usuario que inicia sesion a la variable usuario
                if (usuario != null)
                {
                    _usuarioSesion.UsuarioActual = usuario;
                    Application.Current.MainWindow = _mainWindow;
                    _mainWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Error de inicio de sesión",
                        "Nombre de usuario o contraseña incorrectos.");

                }
            }
        }
    }
}
