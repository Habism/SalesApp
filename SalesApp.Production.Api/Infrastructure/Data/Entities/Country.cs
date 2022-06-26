using SalesApp.Production.Api.Infrastructure.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Infrastructure.Data.Entities
{
    public class Country : BaseEntity
    {
        public int CountryId { get; set; }

        public string Name { get; set; }

    }
}
