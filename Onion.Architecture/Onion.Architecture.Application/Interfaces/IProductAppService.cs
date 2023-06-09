using System;
using AutoMapper;
using Onion.Architecture.Application.Common.BaseModels;
using Onion.Architecture.Application.Common.BaseModels.Dtos;
using Onion.Architecture.Application.Features.ProductOperations.Commands.CreateProduct;
using Onion.Architecture.Domain.Common;
using Onion.Architecture.Domain.Entities;

namespace Onion.Architecture.Application.Interfaces
{
    public interface IProductAppService
    {
        public Task<ServiceResult<IReadOnlyList<ProductListItem>>> GetProducts();
        Task<int> CreateAsync(Product entity);
    }
}

