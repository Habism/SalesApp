using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Dtos.Supplier
{
    public class SupplierUpdateDto : SupplierAddDto
    {
        public int SupplierId { get; set; }
    }
}
