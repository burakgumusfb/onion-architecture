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
        Task<int> Create(T entity);
        Task Update(T entity);
        Task HardDelete(T entity);
        Task BulkInsert(List<T> entities);
        Task BulkUpdate(List<T> entities);
        Task BulkDelete(List<T> entities);
        Task BulkHardDelete(List<T> entities);
        Task Delete(T entity);
    }
}

