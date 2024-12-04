using Microsoft.Extensions.DependencyInjection;
using SannoisWorship.Application.Interfaces;
using SannoisWorship.Application.Services;
using SannoisWorship.Infrastructure.Repositories.Interfaces;
using SannoisWorship.Infrastructure.Repositories;

namespace SannoisWorship.Application.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddSannoisWorshipServices(this IServiceCollection services)
    {

        // Application Services
        services.AddScoped<IUserManagementService, UserManagementService>();
        services.AddScoped<IPartitionService, PartitionService>();
        services.AddScoped<IChantService, ChantService>();

        // Infrastructure Repositories
        services.AddScoped<IPartitionRepository, PartitionRepository>();
        services.AddScoped<IChantRepository, ChantRepository>();

        return services;
    }
}
