using Microsoft.EntityFrameworkCore.Infrastructure;
using Onion.Architecture.Domain.Entities;
using System.Collections.Generic; 
using System.Collections.Generic;
using System.Data;

namespace Onion.Architecture.Application.Interfaces
{
    public interface IUnitofWork
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<Stock> StockRepository{get;}
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync ();
        T GetQuery<T>(string query, object parms, CommandType commandType = CommandType.Text);
        List<T> GetAllQuery<T>(string query, object parms = null, CommandType commandType = CommandType.Text);
        int Execute(string query, object parms = null, CommandType commandType = CommandType.Text);
    }
}