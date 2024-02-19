using Clients.Data.Repository.Clients;
using Clients.Data.Repository.ClientsStatus;
using Microsoft.EntityFrameworkCore;

namespace Clients.Data
{
    public interface IDbContext: IDisposable
    {
        DbSet<DbClient> Clients { get; set; }
        DbSet<DbStatus> Statuses { get; set; }

        Task SaveAsync();
        public void Initialize();
    }
}
