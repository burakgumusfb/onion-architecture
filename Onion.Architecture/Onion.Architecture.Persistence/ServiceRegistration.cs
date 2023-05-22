using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Onion.Architecture.Application.Interfaces;
using Onion.Architecture.Application.Mappings;
using Onion.Architecture.Persistence.Context;

namespace Onion.Architecture.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceApplicationServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitofWork, UnitofWork>();
        services.AddScoped<IProductAppService,ProductAppService>();
        return services;
    }
}

