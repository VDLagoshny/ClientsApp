using Clients.Data.Repository;
using Clients.Data.Repository.Clients;
using Clients.Data.Repository.ClientsStatus;

namespace Clients.Data.Service
{
    public interface IDataService
    {
        IGenericRepository<DbClient> Clients { get; }
        IGenericRepository<DbStatus> Statuses { get; }

        Task<bool> SaveAsync();
    }
}
