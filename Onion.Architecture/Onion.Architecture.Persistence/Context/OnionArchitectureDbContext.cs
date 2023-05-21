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
        public OnionArchitectureDbContext() : base()
        {

        }

        public OnionArchitectureDbContext(DbContextOptions<OnionArchitectureDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                                new Order
                                {
                                    Id = 1,
                                    Description = "Descrption 1",
                                    TotalAmount = 100
                                },
                                new Order
                                {
                                    Id = 2,
                                    Description = "Descrption 2",
                                    TotalAmount = 200
                                },
                                new Order
                                {
                                    Id = 3,
                                    Description = "Descrption 3",
                                    TotalAmount = 300
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

