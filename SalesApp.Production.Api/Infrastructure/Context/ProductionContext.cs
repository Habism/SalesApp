using Microsoft.EntityFrameworkCore;
using SalesApp.Production.Api.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Infrastructure.Context
{
    public class ProductionContext : DbContext
    {
        // private readonly string _connString;

        // public ProductionContext(string connString) => _connString = connString;

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(_connString);

        public ProductionContext(DbContextOptions<ProductionContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}
