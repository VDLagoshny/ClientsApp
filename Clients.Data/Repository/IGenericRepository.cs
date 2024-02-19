namespace Clients.Data.Repository
{
    public interface IGenericRepository<TEntity>
    {
        IQueryable<TEntity> GetQueryable();

        Task CreateAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
