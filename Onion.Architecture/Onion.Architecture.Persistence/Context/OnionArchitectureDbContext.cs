using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Onion.Architecture.Application;
using Onion.Architecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Onion.Architecture.Domain.Common;

namespace Onion.Architecture.Persistence.Context
{
    public class OnionArchitectureDbContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
        public OnionArchitectureDbContext():base()
        {

        }

        public OnionArchitectureDbContext(DbContextOptions<OnionArchitectureDbContext> options) : base(options)
        {

        }
         public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
     {
          foreach (var entry in ChangeTracker.Entries<BaseEntity>())
          {
               switch (entry.State)
               {
                    case EntityState.Added:
                         entry.Entity.CreateDate = DateTime.Now;

                         break;
                    case EntityState.Modified:
                         entry.Entity.UpdateDate = DateTime.Now;
                         break;
               }
          }
          return base.SaveChangesAsync(cancellationToken);
     }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                 .AddJsonFile("appsettings.json")
                 .Build();

             string connectionString = configuration.GetConnectionString("OnionArchitectureDB");

             optionsBuilder
                .UseSqlServer(connectionString)
                .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning));


        }
    }
}

