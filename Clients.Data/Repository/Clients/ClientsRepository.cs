using Microsoft.EntityFrameworkCore;

namespace Clients.Data.Repository.Clients
{
    internal sealed class ClientsRepository: GenericRepository<DbClient>
    {
        public ClientsRepository(DbSet<DbClient> dbSet) : base(dbSet) { }
    }
}
