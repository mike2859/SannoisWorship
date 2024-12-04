using Microsoft.Extensions.DependencyInjection;
using SannoisWorship.Application.Profiles;

namespace SannoisWorship.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {


        services.AddAutoMapper(typeof(MappingProfile)); 
        return services;
    }
}
