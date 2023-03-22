using Locations.Application.Commons.Interfaces.Persistance;
using Locations.Domain.Abstractions;
using Locations.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace Locations.Infrastructure.Persistance.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        protected readonly LocationsDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        public RepositoryBase(LocationsDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();    
        }

        public async Task InsertAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);

                await SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            logger.Info(LogMessages.Info.EntityInserted(entity));
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
                logger.Error(LogMessages.Error.DatabaseErrorOnSaving, ex);
                throw;
            }

            return insertedRows;
        }
    }
}
