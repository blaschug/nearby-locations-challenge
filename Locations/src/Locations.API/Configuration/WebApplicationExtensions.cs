using Locations.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using nearby_locations_challenge.MessagesHub;
using nearby_locations_challenge.Middlewares;

namespace nearby_locations_challenge.Configuration
{
    public static class ApplicationBuilderExtensions
    {
        public static WebApplication AddGlobalErrorHandling(this WebApplication app)
        {
            app.UseMiddleware<GlobalErrorHandlingMiddleware>();

            return app;
        }
        
        public static WebApplication AddSignalrMapping(this WebApplication app)
        {
            app.MapHub<SuccessRequestMessage>("/success-request");

            return app;
        }

        public static WebApplication AddMigrations(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocationsDbContext>();
        
                dbContext.Database.Migrate();
            }

            return app;
        }

        public static WebApplication AddControllersConfigAndRouting(this WebApplication app)
        {
            app.UseRouting();
            app.UseHttpsRedirection();
            app.MapControllers();

            return app;
        }
    }    
}
