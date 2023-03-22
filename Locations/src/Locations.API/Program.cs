using Locations.Application;
using Locations.Infrastructure;
using nearby_locations_challenge;
using nearby_locations_challenge.Configuration;


var logger = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();

try
{
    logger.Info("Initializating application...");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services
        .AddAPI()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

    app
        .AddMigrations()
        .AddGlobalErrorHandling()
        .AddSignalrMapping()
        .AddControllersConfigAndRouting();

    app.Run();
    
    logger.Info("Application initializated succesfully.");
}
catch (Exception e)
{
    logger.Error("Application could not be initializated", e);

    throw;
}
