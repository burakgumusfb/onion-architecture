using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Onion.Architecture.Application.Interfaces;
using Onion.Architecture.Application.Mappings;
using Onion.Architecture.Persistence.Context;

namespace Onion.Architecture.Persistence;

public static class ConfigureService
{
    public static IServiceCollection AddPersistenceApplicationServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitofWork, UnitofWork>();
        services.AddTransient<IProductAppService,ProductAppService>();
        return services;
    }
}

