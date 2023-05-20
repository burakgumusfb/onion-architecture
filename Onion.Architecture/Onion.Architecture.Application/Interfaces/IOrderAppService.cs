using System;
using AutoMapper;

namespace Onion.Architecture.Application.Interfaces
{
    public interface IOrderAppService
    {
        public IEnumerable<OrderListItem> GetOrders();
    }
}

