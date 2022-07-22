using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesApp.Production.Api.Dtos.Country;
using SalesApp.Production.Api.Services.Contracts;
using SalesApp.Production.Api.Services.Core;
using SalesApp.Production.Api.Services.Responses;

namespace SalesApp.Production.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService countryService;
        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet("GetCountries")]
        public async Task<ActionResult<ServiceResponse>> GetCountries()
        {
            ServiceResponse response = new ServiceResponse();

            response = await countryService.GetCountries();

            return Ok(response);
        }

        [HttpGet("GetCountryById")]
        public async Task<ActionResult<ServiceResponse>> GetCountryById(int countryId)
        {
            ServiceResponse response = new ServiceResponse();

            response = await countryService.GetCountryById(countryId);

            return Ok(response);
        }

        [HttpPost("SaveCountry")]
        public async Task<ActionResult<CountryAddResponse>> SaveCountry(CountrySaveDto countrySave)
        {
            CountryAddResponse response = new CountryAddResponse();

            response = await countryService.SaveCountry(countrySave);

            return Ok(response);
        }

        [HttpPost("UpdateCountry")]
        public async Task<ActionResult<CountryUpdateResponse>> UpdateCountry(CountryUpdateDto countryUpdateDto)
        {
            CountryUpdateResponse response = new CountryUpdateResponse();

            response = await countryService.UpdateCountry(countryUpdateDto);

            return Ok(response);
        }

        [HttpPost("RemoveCountry")]
        public async Task<ActionResult<ServiceResponse>> RemoveCountry(CountryRemoveDto countryRemoveDto)
        {
            ServiceResponse response = new ServiceResponse();

            response = await countryService.RemoveCountry(countryRemoveDto);

            return Ok(response);
        }

    }
}
