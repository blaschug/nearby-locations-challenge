using Locations.Application.Commons.Interfaces.Persistance;
using Locations.Domain.LocationsSearches;
using Locations.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace Locations.Infrastructure.Persistance.Repositories
{
    public class LocationRepository 
        : RepositoryBase<LocationSearch>, ILocationRepository
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public LocationRepository(LocationsDbContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task<List<LocationSearch>> GetAll(string? category = null)
        {
            List<LocationSearch> locationSearches = new();
            IQueryable<LocationSearch> query;
            query = _dbSet
                .Include(p => p.Response)
                .ThenInclude(q => q.NearLocations)
                .Include(p => p.Request);
            
            if (!string.IsNullOrEmpty(category)) 
            {
                query = query.Where(p => p.Response.CategoryFilteredBy == category);
            }

            try
            {
                locationSearches = await query.ToListAsync();
            }
            catch(Exception ex)
            {
                logger.Error(LogMessages.Error.DatabaseErrorOnReading, ex);
                throw;
            }

            return locationSearches;
        }
    }   
}
