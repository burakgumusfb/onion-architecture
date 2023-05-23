using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Onion.Architecture.Application.Common.BaseModels;
using Onion.Architecture.Application.Common.BaseModels.Dtos;
using Onion.Architecture.Application.Features.ProductOperations.Commands.CreateProduct;
using Onion.Architecture.Application.Interfaces;
using Onion.Architecture.Domain.Common;
using Onion.Architecture.Domain.Entities;

namespace Onion.Architecture.Application.Mappings
{
    public class ProductAppService : IProductAppService
    {
        private readonly IUnitofWork _uow;
        public ProductAppService(IUnitofWork uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResult<IReadOnlyList<ProductListItem>>> GetProducts()
        {
            var serviceResult = new ServiceResult<IReadOnlyList<ProductListItem>>();

            serviceResult.ResultObject = await this._uow.ProductRepository.GetAll().Select(l => new ProductListItem
            {
                Id = l.Id,
                ProductCode = l.ProductCode,
                ProductName = l.ProductName

            }).ToListAsync();

            return serviceResult;
        }

        public async Task<int> Create(Product product)
        {
            return await this._uow.ProductRepository.Create(product);
        }
    }
}

