
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesApp.Sales.Api.Infrastructure.Data.Entities
{
    [Table("Shippers", Schema = "Sales")]
    public class Shipper
    {
     
        public int Shipperid { get; set; }
        public string Companyname { get; set; }
        public string Phone { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}