using Clients.Data;
using ClientsApp.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ClientsApp
{
    internal class Program
    {
        [STAThread]
        public static void Main()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    // Путь к БД передавать из кофигурационного файла
                    var dbPath = string.Empty;
                    services.AddServiceData(dbPath);
                    services.AddSingleton<AppViewModel>();
                    services.AddSingleton<App>();
                    services.AddSingleton<MainWindow>();
                })
                .Build();

            host.Services.GetRequiredService<IDbContext>().Initialize();

            var app = host.Services.GetService<App>();
            app?.Run();
        }
    }
}
