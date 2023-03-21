using Locations.Application.Locations.Commands.SearchNearbyLocations;
using Locations.Contracts.Providers;
using Locations.Domain.LocationsSearches;

namespace Locations.Application.Locations.Builders
{
    public class LocationSearchBuilder : ILocationSearchBuilder
    {
        public LocationSearch Build(ProviderResult providerResult, SearchNearbyLocationsCommand request)
        {
            throw new NotImplementedException();
        }
    }
}

