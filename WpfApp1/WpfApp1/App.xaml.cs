using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfApp1.Services.Implementations;
using WpfApp1.Services.Interfaces;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //1. Crear contenedor de servicios
            var services = new ServiceCollection();

            //2. Registrar servicios (Singleton para compartir)
            services.AddSingleton<ISharedDataService, SharedDataService>();

            //3. Registrar ViewModels (AQUI deben estar todos los ViewModels que quieran acceder)
            services.AddTransient<MainWindowViewModel>();

            //4. Construir el proveedor de servicios
            ServiceProvider = services.BuildServiceProvider();
        }

    }

}
