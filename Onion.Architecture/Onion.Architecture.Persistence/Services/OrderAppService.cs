using System;
using AutoMapper;
using Onion.Architecture.Application.Interfaces;

namespace Onion.Architecture.Application.Mappings
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IUnitofWork _uow;
        public OrderAppService(IUnitofWork uow)
        {
            _uow = uow;
        }
        public List<OrderListItem> GetOrders()
        {
           var serviceResult = new List<OrderListItem>();
           
           serviceResult = this._uow.OrderRepository.GetAll().Select(l => new OrderListItem
           {
                OrderId = l.Id

           }).ToList();

           return serviceResult;
        }
    }
}

