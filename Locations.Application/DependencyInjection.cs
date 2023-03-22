using System.Reflection;
using FluentValidation;
using Locations.Application.Commons.Behaviours;
using Locations.Application.Locations.Builders;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Locations.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ILocationSearchBuilder, LocationSearchBuilder>();
            
            services.AddMediatrConfiguration();
            
            return services;
        }

        private static IServiceCollection AddMediatrConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            
            return services;
        }
    }    
}
