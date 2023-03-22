using Locations.Application.Commons.Interfaces;
using Locations.Application.Commons.Interfaces.Persistance;
using Locations.Infrastructure.Configurations;
using Locations.Infrastructure.Constants;
using Locations.Infrastructure.Exceptions;
using Locations.Infrastructure.Persistance;
using Locations.Infrastructure.Persistance.Repositories;
using Locations.Infrastructure.Providers.Commons;
using Locations.Infrastructure.Providers.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

namespace Locations.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();

            services
                .AddDbContext(configuration)
                .AddExternalProviders(configuration)
                .AddRepositories();

            return services;
        }

        private static IServiceCollection AddExternalProviders(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var providerConfig = new ProviderConfiguration();
            var configSection = configuration.GetSection(nameof(ProviderConfiguration));
            configSection.Bind(providerConfig);

            switch (providerConfig.ProviderName.ToUpper())
            {
                case ProviderConstants.Google.ProviderName:
                    services.AddScoped<ILocationsProvider, GoogleLocationsProvider>();
                    break;
                default:
                    throw new InvalidLocationsProviderNameException();
            }
            
            services.AddRestClientConfiguration(providerConfig);
            
            return services;
        }

        private static void AddRestClientConfiguration(
            this IServiceCollection services,
            ProviderConfiguration providerConfig)
        {
            var restClient = new RestClient(providerConfig.BaseURL);
            restClient.AddDefaultParameter("radius", providerConfig.FixedRadius);
            restClient.AddDefaultParameter("key", providerConfig.ApiKey);
            
            services.AddSingleton(restClient);
        }

        private static IServiceCollection AddDbContext(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LocationsDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LocationsDatabase"));
            });

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILocationRepository, LocationRepository>();

            return services;
        }
    }
}