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
    public class StockAppService : IStockAppService
    {
        private readonly IUnitofWork _uow;
        public StockAppService(IUnitofWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Create(Stock entity)
        {
            return await this._uow.StockRepository.Create(entity);
        }
    }
}

