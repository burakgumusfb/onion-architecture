using System;
using AutoMapper;
using Onion.Architecture.Application.Common.BaseModels.Dtos;

namespace Onion.Architecture.Application.Interfaces
{
    public interface IProductAppService
    {
        public Task<List<ProductListItem>> GetProducts();
    }
}

