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
        IQueryable<T> Where(Expression<Func<T, bool>> where);
        void Create(T entity);
        void Update(T entity);
        void HardDelete(T entity);
        void BulkInsert(List<T> entities);
        void BulkUpdate(List<T> entities);
        void BulkDelete(List<T> entities);
        void BulkHardDelete(List<T> entities);
        void Delete(T entity);
    }
}

