using System.Reflection;
using Application.Features.ProductOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Onion.Architecture.API.Controllers;
using Onion.Architecture.Application.Common.BaseModels;
using Onion.Architecture.Application.Mappings;
using Onion.Architecture.Persistence;
using Onion.Architecture.Persistence.Context;

namespace Onion.Architecture.API.Tests;

public class ProductControllerTest
{
    private readonly ProductController _productController;

    public ProductControllerTest()
    {
         var serviceProvider = Testing.ServiceProvider;   
         var mediator = serviceProvider.GetRequiredService<IMediator>();   
         this._productController = new ProductController(mediator);
    }

    [Fact]
    public async Task GetProducts()
    {
        var resultProducts = await this._productController.GetProducts(new GetProductsQueryRequest());
        OkObjectResult okObjectResult =  Assert.IsType<OkObjectResult>(resultProducts);
        var result  = okObjectResult.Value as ServiceResult<IReadOnlyList<GetProductsQueryResponse>>;
        Assert.True(result != null && result.ResultObject.Count() > 0);
    }
}
