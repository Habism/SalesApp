using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Dtos.Country
{
    public class CountryUpdateDto : Dtos.BaseDto
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
