using di.proyecto.clase._2026.Datos.Repositorios;
using di.proyecto.clase._2026.Modelos;
using di.proyecto.clase._2026.Servicios;
using di.proyecto.clase._2026.Servicios.Interfaces;
using di.proyecto.clase_2026.Vista.Dialogos;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace di.proyecto.clase._2026
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Defino el contenedor de servicios como un campo privado readonly
        private readonly IServiceProvider _serviceProvider;
        public App()
        {
            // Definimos los servicios para añadir las clases 
            // que queremos inyectar en el contenedor de servicios
            ServiceCollection services = new ServiceCollection();
            // Llamamos al método que tiene las clases que tendremos disponibles
            // en el contenedor de servicios o de objetos en toda la aplicación
            ConfigureServices(services);
            // Construimos el proveedor de servicios
            _serviceProvider = services.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextFactory<DiinventarioexamenContext>();
            services.AddLogging();

            services.AddTransient<Login>();
            services.AddTransient<MainWindow>();
            services.AddTransient<DialogoModeloArticulo>();
            services.AddTransient<Func<Login>>(serviceProvider =>
                () => serviceProvider.GetRequiredService<Login>());
            services.AddTransient<Func<MainWindow>>(serviceProvider =>
                () => serviceProvider.GetRequiredService<MainWindow>());

            services.AddScoped<IUsuarioServicio, UsuarioServicio>();
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddSingleton<UsuarioSesion>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Llamamos al método base para asegurarnos de que la inicialización
            // de la aplicación se realice correctamente
            base.OnStartup(e);
            Login login = _serviceProvider.GetRequiredService<Login>();
            MainWindow = login;
            ShutdownMode = ShutdownMode.OnMainWindowClose;
            login.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            if (_serviceProvider is IDisposable disposable)
                disposable.Dispose();
        }
    }

}
