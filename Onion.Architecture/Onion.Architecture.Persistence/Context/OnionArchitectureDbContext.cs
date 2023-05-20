using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Onion.Architecture.Application;
using Onion.Architecture.Domain.Entities;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


        }
    }
}

