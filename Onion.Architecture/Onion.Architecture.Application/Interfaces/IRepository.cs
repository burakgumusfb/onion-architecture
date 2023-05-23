using System;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Onion.Architecture.Domain.Common;
using Onion.Architecture.Domain.Entities;

namespace Onion.Architecture.Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] properties);
        Task<IQueryable<T>> GetAllAsync(params Expression<Func<T, object>>[] properties);
        IQueryable<T> Where(Expression<Func<T, bool>> where);
        Task<int> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task HardDeleteAsync(T entity);
        Task BulkInsertAsync(List<T> entities);
        Task BulkUpdateAsync(List<T> entities);
        Task BulkDeleteAsync(List<T> entities);
        Task BulkHardDeleteAsync(List<T> entities);
        Task Delete(T entity);
    }
}

