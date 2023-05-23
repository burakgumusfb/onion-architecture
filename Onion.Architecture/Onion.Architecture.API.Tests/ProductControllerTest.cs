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

public class ProductControllerTest
{
    private readonly ProductController _productController;

    
    public ProductControllerTest()
    {
         var services = new ServiceCollection();
         services.AddDbContext<OnionArchitectureDbContext>(option => option.UseSqlServer("Server=localhost,1433; Database=OnionArchitecture; User ID=sa; Password=YourPassword123; TrustServerCertificate=true"));
         services.AddPersistenceApplicationServices();
         services.AddApplicationServices();
         var serviceProvider = services.BuildServiceProvider();
         var mediator = serviceProvider.GetRequiredService<IMediator>();   
         this._productController = new ProductController(mediator);
    }

    [Fact]
    public async Task Test1()
    {
        var result = await this._productController.GetProducts(new GetProductsQueryRequest());
        Assert.Equal(1,1);
    }
}
