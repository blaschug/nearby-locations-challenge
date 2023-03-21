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
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddScoped<ILocationSearchBuilder, LocationSearchBuilder>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            return services;
        }   
    }    
}
