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
        public DbSet<Product> Product { get; set; }
        public OnionArchitectureDbContext() : base()
        {

        }

        public OnionArchitectureDbContext(DbContextOptions<OnionArchitectureDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                                new Product
                                {
                                    Id = 1,
                                    ProductCode = "PC-1",
                                    ProductName = "Product 1"
                                },
                                new Product
                                {
                                    Id = 2,
                                    ProductCode = "PC-2",
                                    ProductName = "Product 2"
                                },
                                new Product
                                {
                                    Id = 3,
                                    ProductCode = "PC-3",
                                    ProductName = "Product 3"
                                }
                         );

            base.OnModelCreating(modelBuilder);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                  var currentDirectory = Directory.GetCurrentDirectory();
                  string parentDirectory = Path.GetDirectoryName(currentDirectory);

                  IConfiguration configuration = new ConfigurationBuilder()
                                   .SetBasePath(parentDirectory + "/Onion.Architecture.API")
                                   .AddJsonFile("appsettings.json")
                                   .Build();

                string connectionString = configuration.GetConnectionString("OnionArchitectureDB");

                optionsBuilder
                   .UseSqlServer(connectionString)
                   .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning));
            }

        }
    }
}

