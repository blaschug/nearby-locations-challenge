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
        
        public Task<SearchNearbyLocationsResponse> Handle(SearchNearbyLocationsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
