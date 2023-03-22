namespace nearby_locations_challenge.Hub;

public interface IMessagesHub
{
    Task SendSuccessRequestAsync(string response);
}