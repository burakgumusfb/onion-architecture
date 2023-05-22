using System;
using AutoMapper;
using Onion.Architecture.Application.Common.BaseModels;
using Onion.Architecture.Application.Common.BaseModels.Dtos;

namespace Onion.Architecture.Application.Interfaces
{
    public interface IProductAppService
    {
        public Task<ServiceResult<IReadOnlyList<ProductListItem>>> GetProducts();
    }
}

