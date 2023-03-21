using Locations.Contracts.Locations;
using MediatR;

namespace Locations.Application.Locations.Commands.SearchNearbyLocations
{
    public class SearchNearbyLocationsCommandHandler
        : IRequestHandler<SearchNearbyLocationsCommand, SearchNearbyLocationsResponse>
    {
        public Task<SearchNearbyLocationsResponse> Handle(SearchNearbyLocationsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
