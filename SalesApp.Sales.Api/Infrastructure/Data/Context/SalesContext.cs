using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Sales.Api.Infrastructure.Data.Context
{
    public class SalesContext : DbContext
    {
        private readonly string _connString;

        public SalesContext(string connString) => _connString = connString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(_connString);
    }
}
