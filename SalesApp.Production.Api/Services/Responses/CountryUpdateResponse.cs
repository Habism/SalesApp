using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesApp.Production.Api.Services.Core;

namespace SalesApp.Production.Api.Services.Responses
{
    public class CountryUpdateResponse : ServiceResponse
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
