using SalesApp.Production.Api.Infrastructure.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Infrastructure.Data.Entities
{
    [Table("Products", Schema = "Production")]
    public class Product : BaseEntity
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public bool Discontinued { get; set; }

        public int SupplierId { get; set; }

        public int CategoryId { get; set; }

        public Category Categories { get; set; }

        public Supplier Suppliers { get; set; }
    }
}
