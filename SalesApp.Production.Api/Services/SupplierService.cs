using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalesApp.Production.Api.Dtos.Supplier;
using SalesApp.Production.Api.Infrastructure.Data.Entities;
using SalesApp.Production.Api.Infrastructure.Data.Repositories.Contracts;
using SalesApp.Production.Api.Services.Contracts;
using SalesApp.Production.Api.Services.Core;
using SalesApp.Production.Api.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ILogger<SupplierService> logger;
        private readonly ISupplierRepository supplierRepository;
        private readonly IConfiguration configuration;

        public SupplierService(ILogger<SupplierService> logger,
                               ISupplierRepository supplierRepository, IConfiguration configuration)
        {
            this.logger = logger;
            this.supplierRepository = supplierRepository;
            this.configuration = configuration;
        }
        public async Task<ServiceResponse> GeSupplierById(int supllierId)
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                response.Data = await supplierRepository.GetSupplierById(supllierId);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error obteniendo el suplidor";
                logger.LogError(response.Message, ex);
            }

            return response;
        }
        public async Task<ServiceResponse> GetSuppliers()
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                response.Data = await supplierRepository.GetSuppliers();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error obteniendo los suplidores";
                logger.LogError(response.Message, ex);
            }

            return response;
        }
        public async Task<ServiceResponse> SaveSupplier(SupplierAddDto supplierAddDto)
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                var resisValidSupplier = isValidSupplier(supplierAddDto.Address, supplierAddDto.PostalCode);

                if (resisValidSupplier != null)
                {
                    if (!resisValidSupplier.Success)
                        return resisValidSupplier;
                }

                Supplier newSupplier = supplierAddDto.ConvertSupplierToSupplierSaveDto();

                await supplierRepository.Add(newSupplier);

                response.Message = this.configuration["MensajesSuplidores:MensajeSave"];
            }
            catch (Exception ex)
            {
                response.Message = this.configuration["MensajesSuplidores:ErrorSaving"];
                response.Success = false;
                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

        public async Task<ServiceResponse> UpdateSupplier(SupplierUpdateDto supplierUpdateDto)
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                var resisValidSupplier = isValidSupplier(supplierUpdateDto.Address, supplierUpdateDto.PostalCode);

                if (resisValidSupplier != null)
                {
                    if (!resisValidSupplier.Success)
                        return resisValidSupplier;
                }

                Supplier suppliers = await supplierRepository.GetById(supplierUpdateDto.SupplierId);

                suppliers.Address = supplierUpdateDto.Address;
                suppliers.City = supplierUpdateDto.City;
                suppliers.CompanyName = supplierUpdateDto.CompanyName;
                suppliers.ContactName = supplierUpdateDto.CompanyName;
                suppliers.ContactTitle = supplierUpdateDto.ContactTitle;
                suppliers.ModifyDate = DateTime.Now;
                suppliers.Country = supplierUpdateDto.Country;
                suppliers.ModifyUser = supplierUpdateDto.UserId;
                suppliers.Fax = supplierUpdateDto.Fax;
                suppliers.Phone = supplierUpdateDto.Phone;
                suppliers.PostalCode = supplierUpdateDto.PostalCode;
                suppliers.Region = supplierUpdateDto.Region;

                await supplierRepository.Update(suppliers);

                response.Message = this.configuration["MensajesSuplidores:MensajeUpdate"];
            }
            catch (Exception ex)
            {

                response.Message = this.configuration["MensajesSuplidores:ErrorUpdating"];
                response.Success = false;
                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

        private ServiceResponse isValidSupplier(string Address, string postalCode)
        {
            ServiceResponse response = null;

            if (string.IsNullOrEmpty(Address))
            {
                response = new ServiceResponse();
                response.Success = false;
                response.Message = this.configuration["MensajesSuplidores:AddressNotEmpty"];
                return response;
            }
            if (Address.Length > 60)
            {
                response = new ServiceResponse();
                response.Success = false;
                response.Message = this.configuration["MensajesSuplidores:InvalidAddressLenght"];
                return response;
            }
            if (!string.IsNullOrEmpty(postalCode))
            {
                if (postalCode.Length > 10)
                {
                    response = new ServiceResponse();
                    response.Success = false;
                    response.Message = this.configuration["MensajesSuplidores:InvalidPostalCodeLenght"];
                    return response;
                }
            }

            return response;
        }
    }
}

