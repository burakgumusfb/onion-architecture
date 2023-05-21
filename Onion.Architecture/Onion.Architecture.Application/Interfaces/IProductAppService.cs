using System;
using AutoMapper;

namespace Onion.Architecture.Application.Interfaces
{
    public interface IProductAppService
    {
        public List<ProductListItem> GetProducts();
    }
}

