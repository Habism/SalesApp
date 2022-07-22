using System;
using SalesApp.Production.Api.Infrastructure.Data.Entities;
using SalesApp.Production.Api.Dtos.Country;

namespace SalesApp.Production.Api.Services.Extensions
{
    public static class CountryExtension
    {
        public static Country ConvertCountryToCountrySaveDto(this CountrySaveDto countrySaveDto)
        {
            return new Country()
            {
                CreationDate = DateTime.Now,
                CreationUser = countrySaveDto.UserId,
                Name = countrySaveDto.Name
            };
        }
        public static Country ConvertCountryToCountryUpdateDto(this CountryUpdateDto countryUpdateDto)
        {
            return new Country()
            {
                ModifyDate = DateTime.Now,
                ModifyUser = countryUpdateDto.UserId,
                Name = countryUpdateDto.Name,
            };
        }
    }
}
