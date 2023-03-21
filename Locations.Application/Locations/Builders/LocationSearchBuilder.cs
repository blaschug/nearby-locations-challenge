using Locations.Application.Commons.Interfaces;
using Locations.Application.Locations.Commands.SearchNearbyLocations;
using Locations.Contracts.Providers;
using Locations.Contracts.Providers.Locations;
using Locations.Domain.LocationsSearches;
using Locations.Domain.LocationsSearches.Entities;
using Locations.Domain.LocationsSearches.ValueObjects;

namespace Locations.Application.Locations.Builders
{
    public class LocationSearchBuilder : ILocationSearchBuilder
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public LocationSearchBuilder(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public LocationSearch Build(ProviderResult providerResult,
            SearchNearbyLocationsCommand request)
        {
            return new LocationSearch
            {
                ProviderName = providerResult.ProviderName,
                Request = new LocationSearchRequest
                {
                    Coordinates = new Coordinates
                    { 
                        Latitude = request.Latitude,
                        Longitude = request.Longitude
                    },
                    Category = request.Category
                },
                Response = new LocationSearchResponse
                {
                    CategoryFilteredBy = request.Category,
                    NearLocations = providerResult.NearbyLocationsFound.ConvertAll<LocationInfo>(x =>
                    {
                        return new LocationInfo
                        {
                            Coordinates = new Coordinates
                            {
                                Latitude = x.Latitude,
                                Longitude = x.Longitude
                            },
                            LocationId = x.LocationId,
                            Name = x.Name,
                        };
                    })
                },
                Created = _dateTimeProvider.UtcNow
            };
        }
    }
}

