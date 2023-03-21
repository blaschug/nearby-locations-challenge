using Locations.Application.Locations.Commands.SearchNearbyLocations;
using Locations.Application.Locations.Queries.GetAllSearches;
using Locations.Contracts.Locations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace nearby_locations_challenge.Controllers
{
    [Route("locations")]
    public class LocationController : ApiControllerBase
    {
        private readonly ISender _mediator;

        public LocationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("nearby")]
        public async Task<IActionResult> SearchNearbyLocations(SearchNearbyLocationsRequest request)
        {
            var command = new SearchNearbyLocationsCommand(request.Latitude,
                request.Longitude,
                request.Category);

            var searchNearbyLocationsResponse = await _mediator.Send(command);

            return Created($"{Request.Path}", searchNearbyLocationsResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSearches()
        {
            var query = new GetAllSearchesQuery();

            var allSearchesResponse = await _mediator.Send(query);

            return Ok(allSearchesResponse);
        }
    }
}
