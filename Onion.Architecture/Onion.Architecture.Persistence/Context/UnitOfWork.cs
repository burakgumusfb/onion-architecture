using Advanced.Field.Data.Context;
using Dapper;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Onion.Architecture.Application.Interfaces;
using Onion.Architecture.Application.Mappings;
using Onion.Architecture.Domain.Entities;
using Onion.Architecture.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Advanced.Field.Data.Context
{
    public class UnitofWork : IUnitofWork
    {
        private bool Disposed = false;
        private readonly OnionArchitectureDbContext DB;

        private IRepository<Order> _orderRepository;

        private IDbContextTransaction _transaction;
        private readonly IHttpContextAccessor HttpContextAccessor;

        public IRepository<Order> OrderRepository => _orderRepository ??= new Repository<Order>(DB);

        public UnitofWork(OnionArchitectureDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            DB = db;
            HttpContextAccessor = httpContextAccessor;
        }

        public void BeginTransaction()
        {
            if (DB.Database.CurrentTransaction == null)
            {
                _transaction = DB.Database.BeginTransaction();
            }
        }
        public void Commit()
        {
            if (DB.Database.CurrentTransaction != null)
            {
                _transaction.Commit();
                _transaction.Dispose();
            }
        }
        public void Rollback()
        {
            if (DB.Database.CurrentTransaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
            }
        }

        public T GetQuery<T>(string query, object parms, CommandType commandType = CommandType.Text)
        {
            var transaction = DB.Database.CurrentTransaction?.GetUnderlyingTransaction(new BulkConfig() { });
            if (transaction != null)
                return DB.Database.GetDbConnection().Query<T>(query, parms, commandType: commandType, transaction: transaction, commandTimeout: 3600).FirstOrDefault();
            else
                return DB.Database.GetDbConnection().Query<T>(query, parms, commandType: commandType, commandTimeout: 3600).FirstOrDefault();
        }
        public List<T> GetAllQuery<T>(string query, object parms = null, CommandType commandType = CommandType.Text)
        {
            var transaction = DB.Database.CurrentTransaction?.GetUnderlyingTransaction(new BulkConfig() { });
            if (transaction != null)
                return DB.Database.GetDbConnection().Query<T>(query, parms, commandType: commandType, transaction: transaction,commandTimeout:3600).ToList();
            else
                return DB.Database.GetDbConnection().Query<T>(query, parms, commandType: commandType, commandTimeout: 3600).ToList();

        }
        public int Execute(string query, object parms = null, CommandType commandType = CommandType.Text)
        {
            var transaction = DB.Database.CurrentTransaction?.GetUnderlyingTransaction(new BulkConfig() { });
            if (transaction == null)
                throw new Exception("transaction_problem");

            var result = DB.Database.GetDbConnection().Execute(query, parms, commandType: commandType, transaction: transaction,commandTimeout: 3600);
            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    _transaction.Dispose();
                    DB.Dispose();
                }
            }
            Disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}