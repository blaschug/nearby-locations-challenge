using Locations.Application.Commons.Interfaces;
using Locations.Application.Commons.Interfaces.Persistance;
using Locations.Application.Locations.Builders;
using Locations.Contracts.Locations;
using MediatR;

namespace Locations.Application.Locations.Commands.SearchNearbyLocations
{
    public class SearchNearbyLocationsCommandHandler
        : IRequestHandler<SearchNearbyLocationsCommand, SearchNearbyLocationsResponse>
    {
        private readonly ILocationsProvider _locationsProvider;
        private readonly ILocationRepository _locationRepository;
        private readonly ILocationSearchBuilder _locationSearchBuilder;

        public SearchNearbyLocationsCommandHandler(
            ILocationsProvider locationsProvider,
            ILocationRepository locationRepository,
            ILocationSearchBuilder locationSearchBuilder)
        {
            _locationsProvider = locationsProvider;
            _locationRepository = locationRepository;
            _locationSearchBuilder = locationSearchBuilder;
        }
        
        public async Task<SearchNearbyLocationsResponse> Handle(SearchNearbyLocationsCommand request, CancellationToken cancellationToken)
        {
            var providerResult = await _locationsProvider.SearchLocationsAsync(request.Latitude,
                request.Longitude,
                request.Category);

            var locationSearch = _locationSearchBuilder.Build(providerResult, request);                           

            await _locationRepository.InsertAsync(locationSearch);

            return new SearchNearbyLocationsResponse(
                request.Latitude,
                request.Longitude,
                request.Category,
                providerResult.NearbyLocationsFound.ConvertAll<NearbyLocationInfoResponse>(x => 
                    new NearbyLocationInfoResponse(
                        x.LocationId,
                        x.Name,
                        x.Latitude,
                        x.Longitude)));
        }
    }
}
