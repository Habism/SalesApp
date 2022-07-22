using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Dtos.Country
{
    public class CountryRemoveDto : Dtos.BaseDto
    {
        public int CountryId { get; set; }
        public int? DeleteUser { get; set; }
        public DateTime DeleteDate { get; set; }
    }
}
