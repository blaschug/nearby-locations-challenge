using Microsoft.AspNetCore.SignalR;

namespace nearby_locations_challenge.Hub
{
    public class SuccessRequestMessage : Microsoft.AspNetCore.SignalR.Hub, IMessagesHub
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
