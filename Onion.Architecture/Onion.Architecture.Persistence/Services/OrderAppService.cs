using System;
using AutoMapper;
using Onion.Architecture.Application.Interfaces;

namespace Onion.Architecture.Application.Mappings
{
    public class OrderAppService : IOrderAppService
    {
        public IEnumerable<OrderListItem> GetOrders()
        {
            yield return new OrderListItem() { OrderId = 1 };
            yield return new OrderListItem() { OrderId = 2 };
        }
    }
}

