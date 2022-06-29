using Microsoft.Extensions.Logging;
using SalesApp.Production.Api.Infrastructure.Data.Context;
using SalesApp.Production.Api.Infrastructure.Data.Core;
using SalesApp.Production.Api.Infrastructure.Data.Entities;
using SalesApp.Production.Api.Infrastructure.Data.Models;
using SalesApp.Production.Api.Infrastructure.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Infrastructure.Data.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        private readonly ILogger<CountryRepository> _logger;

        public CountryRepository(ProductionContext context, ILogger<CountryRepository> logger) : base(context)
        {
            this._logger = logger;
        }

        public Task<List<CountryModel>> GetCountries()
        {
            throw new NotImplementedException();
        }
    }
}
