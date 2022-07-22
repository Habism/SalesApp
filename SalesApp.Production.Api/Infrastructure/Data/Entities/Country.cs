using SalesApp.Production.Api.Infrastructure.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Infrastructure.Data.Entities
{
    [Table("Countries", Schema = "Production")]
    public class Country : BaseEntity
    {
        public int CountryId { get; set; }

        public string Name { get; set; }

    }
}
