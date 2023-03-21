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
            IQueryable<LocationSearch> query;

            if (string.IsNullOrEmpty(category)) 
            {
                query = _dbSet.Where(p => p.Response.CategoryFilteredBy == category);
            }
            else
            {
                query = _dbSet.AsQueryable();
            }

            query.Include(p => p.Response).Include(p => p.Request);

            return await query.ToListAsync();
        }
    }   
}
