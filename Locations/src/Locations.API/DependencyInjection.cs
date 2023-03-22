using nearby_locations_challenge.MessagesHub;

namespace nearby_locations_challenge;

public static class DependencyInjection
{
    public static IServiceCollection AddAPI(this IServiceCollection services)
    {
        services.AddControllers();

        services
            .AddSignalRConfigAndMessages();
        
        return services;
    }

    private static IServiceCollection AddSignalRConfigAndMessages(this IServiceCollection services)
    {
        services.AddScoped<IMessagesHub, SuccessRequestMessage>();

        services.AddSignalR();

        return services;
    }
}