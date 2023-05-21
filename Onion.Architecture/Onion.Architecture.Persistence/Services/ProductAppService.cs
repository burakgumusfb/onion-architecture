using System;
using AutoMapper;
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
        public List<ProductListItem> GetProducts()
        {
           var serviceResult = new List<ProductListItem>();
           
           serviceResult = this._uow.ProductRepository.GetAll().Select(l => new ProductListItem
           {
                ProductId = l.Id

           }).ToList();

           return serviceResult;
        }
    }
}

