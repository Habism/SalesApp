
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesApp.Sales.Api.Infrastructure.Data.Entities
{
    [Table("Orders", Schema = "Sales")]
    public class Order
    {

        public int Orderid { get; set; }
        public int? Custid { get; set; }
        public int Empid { get; set; }
        public DateTime Orderdate { get; set; }
        public DateTime Requireddate { get; set; }
        public DateTime? Shippeddate { get; set; }
        public int Shipperid { get; set; }
        public decimal Freight { get; set; }
        public string Shipname { get; set; }
        public string Shipaddress { get; set; }
        public string Shipcity { get; set; }
        public string Shipregion { get; set; }
        public string Shippostalcode { get; set; }
        public string Shipcountry { get; set; }

        public Customer Cust { get; set; }
        //public Employees Emp { get; set; }
        //public Shippers Shipper { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}