using Locations.Application;
using Locations.Infrastructure;
using Locations.Infrastructure.Persistance;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using nearby_locations_challenge;
using nearby_locations_challenge.Configuration;
using nearby_locations_challenge.MessagesHub;
using nearby_locations_challenge.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddAPI()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app
    .AddMigrations()
    .AddGlobalErrorHandling()
    .AddSignalrMapping()
    .AddControllersConfigAndRouting();

app.Run();