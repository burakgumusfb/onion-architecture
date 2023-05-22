using System;
using System.Linq.Expressions;
using AutoMapper;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Onion.Architecture.Application.Interfaces;
using Onion.Architecture.Domain.Common;
using Onion.Architecture.Domain.Entities;
using Onion.Architecture.Persistence.Context;

namespace Onion.Architecture.Application.Mappings
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly OnionArchitectureDbContext _db;
        private DatabaseFacade transaction { get; set; }
        public Repository(OnionArchitectureDbContext db)
        {
            _db = db;
        }
        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] properties)
        {
            var query = _db.Set<T>().AsNoTracking();

            if (properties.Any())
            {
                query = properties.Aggregate(query, (current, property) => current.Include(property));
            }
            return query;
        }
      public async Task<IQueryable<T>> GetAllAsync(params Expression<Func<T, object>>[] properties)
        {
            var query = _db.Set<T>().AsNoTracking();

            if (properties.Any())
            {
                query = properties.Aggregate(query, (current, property) => current.Include(property));
            }

            return await Task.FromResult(query);
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> where)
        {
            return _db.Set<T>().Where(where);
        }
        public void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.CreateDate = DateTime.Now;
            entity.CreateUserId = UserID;
            _db.Add(entity);
            _db.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.ModifyDate = DateTime.Now;
            entity.ModifyUserId = UserID;
            _db.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            _db.Entry(entity).Property(x => x.ModifyDate).IsModified = false;
            _db.Entry(entity).Property(x => x.ModifyUserId).IsModified = false;
            _db.Entry(entity).Property(x => x.CreateUserId).IsModified = false;
            _db.Entry(entity).Property(x => x.CreateDate).IsModified = false;
            _db.SaveChanges();
        }
        public void HardDelete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _db.Remove(entity);
            _db.SaveChanges();
        }
        public void BulkInsert(List<T> entities)
        {
            var createDate = DateTime.Now;
            foreach (var entity in entities)
            {
                entity.CreateDate = createDate;
                entity.CreateUserId = UserID;
            }
            _db.BulkInsert(entities);
        }
        public void BulkUpdate(List<T> entities)
        {
            var modifyDate = DateTime.Now;
            foreach (var entity in entities)
            {
                entity.ModifyDate = modifyDate;
                entity.ModifyUserId = UserID;
            }
            var bulkConfig = new BulkConfig()
            {
                PropertiesToExclude = new List<string>
                {
                    "CreateDate",
                    "CreateUserID",
                    "GUID",
                }
            };
            _db.BulkUpdate(entities, bulkConfig);
        }
        public void BulkDelete(List<T> entities)
        {
            var deleteDate = DateTime.Now;
            foreach (var entity in entities)
            {
                entity.DeleteDate = deleteDate;
                entity.DeleteUserId = UserID;
                entity.IsDeleted = true;
            }
            var bulkConfig = new BulkConfig()
            {
                PropertiesToExclude = new List<string>
                {
                    "ModifyDate",
                    "ModifyUserID",
                    "CreateDate",
                    "CreateUserID",
                    "GUID",
                }
            };
            _db.BulkUpdate(entities, bulkConfig);
        }
        public void BulkHardDelete(List<T> entities)
        {
            _db.BulkDelete(entities);
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.IsDeleted = true;
            entity.DeleteDate = DateTime.Now;
            entity.DeleteUserId = this.UserID;
            _db.Entry(entity).Property(x => x.ModifyDate).IsModified = false;
            _db.Entry(entity).Property(x => x.ModifyUserId).IsModified = false;
            _db.Entry(entity).Property(x => x.CreateUserId).IsModified = false;
            _db.Entry(entity).Property(x => x.CreateDate).IsModified = false;
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        protected void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        ~Repository()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public int UserID
        {
            get
            {
                return 1;
            }
        }
    }
}

