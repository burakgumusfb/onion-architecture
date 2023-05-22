using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Onion.Architecture.Application.Interfaces;

namespace Onion.Architecture.Application.Mappings
{
    public class ProductAppService : IProductAppService
    {
        private readonly IUnitofWork _uow;
        public ProductAppService(IUnitofWork uow)
        {
            _uow = uow;
        }
        public async Task<List<ProductListItem>> GetProducts()
        {
           var serviceResult = new List<ProductListItem>();
           
           serviceResult = await this._uow.ProductRepository.GetAll().Select(l => new ProductListItem
           {
                Id = l.Id,
                ProductCode = l.ProductCode,
                ProductName = l.ProductName

           }).ToListAsync();

           return serviceResult;
        }
    }
}

