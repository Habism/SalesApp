using System.Threading.Tasks;
using SalesApp.Production.Api.Services.Core;
using SalesApp.Production.Api.Services.Responses;
using SalesApp.Production.Api.Dtos.Country;

namespace SalesApp.Production.Api.Services.Contracts
{
    public interface ICountryService
    {
        Task<ServiceResponse> GetCountries();
        Task<ServiceResponse> GetCountryById(int countryId);
        Task<CountryAddResponse> SaveCountry(CountrySaveDto countrySaveDto);
        Task<CountryUpdateResponse> UpdateCountry(CountryUpdateDto countryUpdateDto);
        Task<ServiceResponse> RemoveCountry(CountryRemoveDto countryRemoveDto);

    }
}

