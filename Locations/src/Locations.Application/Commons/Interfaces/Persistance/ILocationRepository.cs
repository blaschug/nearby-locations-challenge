using Locations.Domain.LocationsSearches;

namespace Locations.Application.Commons.Interfaces.Persistance
{
    public interface ILocationRepository : IRepositoryBase<LocationSearch>
    {
        Task<List<LocationSearch>> GetAll(string? category = null);
    }
}