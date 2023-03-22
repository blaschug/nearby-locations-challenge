using Locations.Application;
using Locations.Infrastructure;
using Locations.Infrastructure.Persistance;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using nearby_locations_challenge;
using nearby_locations_challenge.MessagesHub;

var builder = WebApplication.CreateBuilder(args);

//application DI
builder.Services
    .AddAPI()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<LocationsDbContext>();
        
        dbContext.Database.Migrate();
    }
}

app.UseRouting();
app.MapHub<SuccessRequestMessage>("/success-request");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();