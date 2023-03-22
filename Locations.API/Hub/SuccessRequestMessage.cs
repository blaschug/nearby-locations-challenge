using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using HubConnectionContext = Microsoft.AspNetCore.SignalR.HubConnectionContext;

namespace nearby_locations_challenge.MessagesHub
{
    public class SuccessRequestMessage : Hub, IMessagesHub
    {
        private readonly IHubContext<SuccessRequestMessage> _messagesHub;

        public SuccessRequestMessage(IHubContext<SuccessRequestMessage> messagesHub)
        {
            _messagesHub = messagesHub;
        }

        public async Task SendSuccessRequestAsync(string response)
        {
            await _messagesHub.Clients.All.SendAsync("SuccessRequest", response);
        }
    }    
}
