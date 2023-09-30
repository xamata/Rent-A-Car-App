using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentACarAppLibrary.Data;
using RentACarAppLibrary.Databases;
using System.IO;
using System.Windows;

namespace RentACarApp.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider serviceProvider;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            services.AddTransient<MainWindow>();
            services.AddTransient<CheckInForm>();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();

            services.AddTransient<IDatabaseData, SqlData>();

            services.AddTransient<ISqlDataAccess, SqlDataAccess>();

            services.AddSingleton(config);

            serviceProvider = services.BuildServiceProvider();
            var mainWindow = serviceProvider.GetService<MainWindow>();

            mainWindow.Show();
        }
    }
}
