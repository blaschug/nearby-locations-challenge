using Locations.Application.Commons.Interfaces.Persistance;
using Locations.Domain.LocationsSearches;
using Microsoft.EntityFrameworkCore;

namespace Locations.Infrastructure.Persistance.Repositories
{
    public class LocationRepository 
        : RepositoryBase<LocationSearch>, ILocationRepository
    {
        public LocationRepository(LocationsDbContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task<List<LocationSearch>> GetAll(string? category = null)
        {
            List<LocationSearch> locationSearches;
            IQueryable<LocationSearch> query;
            query = _dbSet
                .Include(p => p.Response)
                .ThenInclude(q => q.NearLocations)
                .Include(p => p.Request);
            
            if (!string.IsNullOrEmpty(category)) 
            {
                locationSearches = await query.Where(p => p.Response.CategoryFilteredBy == category).ToListAsync();
            }
            else
            {
                locationSearches = await query.ToListAsync();
            }

            // query.Include(p => p.Response).Include(p => p.Request);

            return locationSearches;
        }
    }   
}
