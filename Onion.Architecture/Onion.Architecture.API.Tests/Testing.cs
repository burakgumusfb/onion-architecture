using System.Reflection;
using Application.Features.ProductOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Onion.Architecture.API.Controllers;
using Onion.Architecture.Application.Mappings;
using Onion.Architecture.Persistence;
using Onion.Architecture.Persistence.Context;

namespace Onion.Architecture.API.Tests;

public sealed class Testing
{
    private static ServiceProvider? instance;
    private static readonly object lockObject = new object();

    private Testing()
    {
    }

    public static ServiceProvider ServiceProvider
    {
        get
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        var services = new ServiceCollection();
                        services.AddDbContext<OnionArchitectureDbContext>(option => option.UseSqlServer("Server=localhost,1433; Database=OnionArchitecture; User ID=sa; Password=YourPassword123; TrustServerCertificate=true"));
                        services.AddPersistenceApplicationServices();
                        services.AddApplicationServices();
                        instance = services.BuildServiceProvider();
                        return instance;
                    }
                }
            }
            return instance;
        }
    }

    // Other methods and properties of the Singleton class
}

