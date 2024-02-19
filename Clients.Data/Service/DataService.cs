using Clients.Data.Repository;
using Clients.Data.Repository.Clients;
using Clients.Data.Repository.ClientsStatus;

namespace Clients.Data.Service
{
    public sealed class DataService: IDataService
    {
        private readonly IDbContext _dbContext;

        private IGenericRepository<DbClient> _clients;
        private IGenericRepository<DbStatus> _statuses;

        public DataService(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        public IGenericRepository<DbClient> Clients =>
            _clients ??= new ClientsRepository(_dbContext.Clients);

        public IGenericRepository<DbStatus> Statuses =>
            _statuses ??= new StatusRepository(_dbContext.Statuses);

        public async Task<bool> SaveAsync()
        {
            await _dbContext.SaveAsync().ConfigureAwait(false);
            return true;
        }
    }
}
