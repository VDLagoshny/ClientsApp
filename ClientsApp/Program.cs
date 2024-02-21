using Clients.Data;
using ClientsApp.Model.ModelService;
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
                    var dbPath = @"Data Source=ClientAppDb.sqlite";
                    services.AddServiceData(dbPath);
                    services.AddTransient<IClientService, ClientService>();
                    services.AddTransient<AppViewModel>();
                    services.AddTransient<App>();
                    services.AddTransient<MainWindow>();
                })
                .Build();

            host.Services.GetRequiredService<IDbContext>().Initialize();

            var app = host.Services.GetService<App>();
            app?.Run();
        }
    }
}
