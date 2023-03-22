namespace nearby_locations_challenge.MessagesHub;

public interface IMessagesHub
{
    Task SendSuccessRequestAsync(string response);
}