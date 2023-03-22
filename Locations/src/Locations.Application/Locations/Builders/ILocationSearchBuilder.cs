using Locations.Application.Locations.Commands.SearchNearbyLocations;
using Locations.Contracts.Providers;
using Locations.Contracts.Providers.Locations;
using Locations.Domain.LocationsSearches;

namespace Locations.Application.Locations.Builders;

public interface ILocationSearchBuilder
{
    LocationSearch Build(
        ProviderResult providerResult,
        SearchNearbyLocationsCommand request);
}