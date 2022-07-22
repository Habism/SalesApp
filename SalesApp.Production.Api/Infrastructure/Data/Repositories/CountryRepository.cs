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
        private readonly ProductionContext context;

        public CountryRepository(ProductionContext context, ILogger<CountryRepository> logger) : base(context)
        {
            this._logger = logger;
            this.context = context;
        }

        public async Task<List<CountryModel>> GetCountries()
        {
            List<CountryModel> countries = new List<CountryModel>();

            try
            {
                countries = (await base.Get())
                                        .Where(co => !co.Deleted)
                                        .Select(country => new CountryModel()
                                        {
                                            CountryId = country.CountryId,
                                            CreationDate = country.CreationDate,
                                            Name = country.Name
                                        })
                                        .OrderBy(co => co.Name)
                                        .ToList();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo los paises", ex.ToString());
            }

            return countries;
        }
        public async override Task Add(Country entity)
        {
            try
            {
                if (await base.Exists(co => co.Name == entity.Name))
                {
                    throw new Exceptions.CountryException($"El pais { entity.Name } ya se encuentra registrado.");
                }

                await base.Add(entity);

            }
            catch (Exception ex)
            {
                this._logger.LogError("Error agregando el pais", ex.ToString());
            }
        }

    }
}
