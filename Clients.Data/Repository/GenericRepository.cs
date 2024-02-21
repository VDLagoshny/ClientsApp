using Microsoft.EntityFrameworkCore;

namespace Clients.Data.Repository
{
    internal abstract class GenericRepository<TEntity>: IGenericRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbSet<TEntity> _dbSet;

        protected GenericRepository(DbSet<TEntity> dbSet) 
        {
            _dbSet = dbSet;
        }

        public IQueryable<TEntity> GetQueryable() 
        { 
            return _dbSet.AsQueryable();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity).ConfigureAwait(false);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(TEntity entity) 
        { 
            _dbSet.Remove(entity);
        }
    }
}
