using Clients.Data.Repository.Clients;
using Clients.Data.Repository.ClientsStatus;
using Microsoft.EntityFrameworkCore;

namespace Clients.Data
{
    internal sealed class AppDbContext: DbContext, IDbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<DbClient> Clients { get; set; }
        public DbSet<DbStatus> Statuses { get; set; }


        public async Task SaveAsync()
        {
            await SaveChangesAsync();
        }

        public void Initialize()
        {
            try
            {
                Database.Migrate();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data context initialization failed.", ex);
            }
        }
    }
}
