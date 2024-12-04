using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SannoisWorship.Application.Interfaces;
using SannoisWorship.Application.Services;
using SannoisWorship.Infrastructure.Repositories.Interfaces;
using SannoisWorship.Infrastructure.Repositories;
using SannoisWorship.Application.Extensions;


var builder = WebAssemblyHostBuilder.CreateDefault(args);


//builder.Services.AddScoped<IPartitionRepository, PartitionRepository>();
//builder.Services.AddScoped<IChantRepository, ChantRepository>();


//builder.Services.AddScoped<IUserManagementService, UserManagementService>();
//builder.Services.AddScoped<IPartitionService, PartitionService>();
//builder.Services.AddScoped<IChantService, ChantService>();

// Ajout des services personnalisés
builder.Services.AddSannoisWorshipServices();

builder.Services.AddApplicationServices();


await builder.Build().RunAsync();
