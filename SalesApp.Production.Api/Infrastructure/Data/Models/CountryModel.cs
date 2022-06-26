using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Infrastructure.Data.Models
{
    public class CountryModel
    {
        public int CountryId { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
