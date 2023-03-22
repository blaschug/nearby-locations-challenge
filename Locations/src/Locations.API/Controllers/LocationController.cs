using Locations.Application.Locations.Commands.SearchNearbyLocations;
using Locations.Application.Locations.Queries.GetAllSearches;
using Locations.Contracts.Locations;
using Locations.Infrastructure.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using nearby_locations_challenge.Hub;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace nearby_locations_challenge.Controllers
{
    [Route("locations")]
    public class LocationController : ApiControllerBase
    {
        private readonly ISender _mediator;
        private readonly IHubContext<SuccessRequestMessage> _messagesHub;
        private readonly IMessagesHub _messagesHub2;

        public LocationController(ISender mediator, IHubContext<SuccessRequestMessage> messagesHub, IMessagesHub messagesHub2)
        {
            _mediator = mediator;
            _messagesHub = messagesHub;
            _messagesHub2 = messagesHub2;
        }

        [HttpPost("nearby")]
        public async Task<IActionResult> SearchNearbyLocations(SearchNearbyLocationsRequest request)
        {
            var command = new SearchNearbyLocationsCommand(request.Latitude,
                request.Longitude,
                request.Category);

            var searchNearbyLocationsResponse = await _mediator.Send(command);

            await _messagesHub2.SendSuccessRequestAsync(JsonConvert.SerializeObject(searchNearbyLocationsResponse));
            
            // await _messagesHub.Clients.All.SendAsync("SuccessRequest", JsonConvert.SerializeObject(searchNearbyLocationsResponse));
            
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
