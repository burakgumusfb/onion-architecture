using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Onion.Architecture.Application.Interfaces;
using Onion.Architecture.Application.Mappings;

namespace Onion.Architecture.Persistence;

public static class ConfigureService
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IOrderAppService,OrderAppService>();
        return services;
    }
}

