using System;
using AutoMapper;

namespace Onion.Architecture.Application.Interfaces
{
    public interface IProductAppService
    {
        public Task<List<ProductListItem>> GetProducts();
    }
}

