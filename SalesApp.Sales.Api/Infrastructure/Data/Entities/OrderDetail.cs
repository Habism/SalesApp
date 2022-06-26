using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesApp.Sales.Api.Infrastructure.Data.Entities
{
    [Table("OrderDetails", Schema = "Sales")]
    public  class OrderDetail
    {
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public decimal Unitprice { get; set; }
        public short Qty { get; set; }
        public decimal Discount { get; set; }

        public Order Order { get; set; }
        //public Products Product { get; set; }
    }
}