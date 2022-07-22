using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SalesApp.Production.Api.Infrastructure.Data.Entities;
using SalesApp.Production.Api.Services.Contracts;
using SalesApp.Production.Api.Services.Core;
using SalesApp.Production.Api.Services.Responses;
using Microsoft.Extensions.Configuration;
using SalesApp.Production.Api.Dtos.Country;
using SalesApp.Production.Api.Services.Extensions;
using SalesApp.Production.Api.Infrastructure.Data.Repositories.Contracts;

namespace SalesApp.Production.Api.Services
{
    public class CountryService : ICountryService
    {
        private readonly ILogger<CountryService> logger;
        private readonly ICountryRepository countryRespository;
        private readonly IConfiguration configuration;

        public CountryService(ILogger<CountryService> logger,
                              ICountryRepository countryRespository,
                              IConfiguration configuration
                              )
        {
            this.logger = logger;
            this.countryRespository = countryRespository;
            this.configuration = configuration;
        }

        public async Task<ServiceResponse> GetCountries()
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                response.Data = await countryRespository.GetCountries();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error obteniendo los paises";
                this.logger.LogError(response.Message, ex.ToString());
            }
            return response;
        }

        public async Task<ServiceResponse> GetCountryById(int countryId)
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                CountryDetailResponse countryDetail = new CountryDetailResponse(); ;

                var countryFound = await countryRespository.GetByEntity(ca => ca.CountryId == countryId
                                                                    && !ca.Deleted);
                countryDetail.Id = countryFound.CountryId;
                countryDetail.Name = countryFound.Name;
                countryDetail.CreationDate = countryFound.CreationDate;

                response.Data = countryDetail;

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error obteniendo los paises";
                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

        public async Task<ServiceResponse> RemoveCountry(CountryRemoveDto countryRemove)
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                Country removeCountry = await this.countryRespository.GetById(countryRemove.CountryId);

                removeCountry.DeleteDate = Convert.ToDateTime(countryRemove.ChangeDate);
                removeCountry.DeleteUser = countryRemove.UserId;
                removeCountry.Deleted = true;

                await countryRespository.Remove(removeCountry);

                response.Message = this.configuration["MensajesCountry:MensajeRemove"];
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error guardando el pais";
                this.logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

        public async Task<CountryAddResponse> SaveCountry(CountrySaveDto countrySave)
        {
            CountryAddResponse response = new CountryAddResponse();
            try
            {
                if (string.IsNullOrEmpty(countrySave.Name))
                {
                    response.Success = false;
                    response.Message = this.configuration["MensajesCountry:MensajeNombreRequerido"];
                    return response;
                }

                Country newCountry = countrySave.ConvertCountryToCountrySaveDto();

                await countryRespository.Add(newCountry);

                response.CountryId = newCountry.CountryId.ToString();

                response.Message = this.configuration["MensajesCountry:MensajeSave"];

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error guardando el pais";
                this.logger.LogError(response.Message, ex.ToString());
            }
            return response;
        }


        public async Task<CountryUpdateResponse> UpdateCountry(CountryUpdateDto countryUpdateDto)
        {
            CountryUpdateResponse response = new CountryUpdateResponse();

            try
            {
                Country updateCountry = await this.countryRespository.GetById(countryUpdateDto.CountryId);

                updateCountry.ModifyDate = DateTime.Now;
                updateCountry.Name = countryUpdateDto.Name;
                updateCountry.ModifyUser = countryUpdateDto.UserId;

                await countryRespository.Update(updateCountry);

                response.Name = updateCountry.Name;
                response.CountryId = updateCountry.CountryId;

                response.Message = this.configuration["MensajesCountry:MensajeUpdate"];
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error actualizando el pais: { countryUpdateDto.Name }";
                this.logger.LogError(response.Message, ex.ToString());
            }


            return response;
        }
    }
}
