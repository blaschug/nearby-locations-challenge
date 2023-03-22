using Locations.Application.Commons.Interfaces.Persistance;
using Locations.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Locations.Infrastructure.Persistance.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        protected readonly LocationsDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public RepositoryBase(LocationsDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();    
        }

        public async Task InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

            await SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            int insertedRows;

            try
            {
                insertedRows = await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //TODO: Add log
                throw;
            }

            return insertedRows;
        }
    }
}
