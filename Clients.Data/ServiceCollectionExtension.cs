using Clients.Data.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Clients.Data
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServiceData(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(o => o.UseSqlite(connectionString))
                .AddTransient<IDbContext, AppDbContext>()
                .AddTransient<IDataService, DataService>();


            return services;
        }
    }
}
