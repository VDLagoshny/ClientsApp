using Microsoft.EntityFrameworkCore;

namespace Clients.Data.Repository.ClientsStatus
{
    internal sealed class StatusRepository: GenericRepository<DbStatus>
    {
        public StatusRepository(DbSet<DbStatus> dbSet) :base(dbSet) { }
    }
}
