using SalesApp.Production.Api.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Services.Responses
{
    public class CountryAddResponse : ServiceResponse
    {
        public string CountryId { get; set; }
    }
}
