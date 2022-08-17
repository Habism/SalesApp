using SalesApp.Production.Api.Dtos;
using SalesApp.Production.Api.Dtos.Supplier;
using SalesApp.Production.Api.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Services.Extensions
{
    public static class SupplierExtension
    {
        public static Supplier ConvertSupplierToSupplierSaveDto(this SupplierAddDto supplierAddDto)
        {
            return new Supplier()
            {
                Address = supplierAddDto.Address,
                City = supplierAddDto.City,
                CompanyName = supplierAddDto.CompanyName,
                ContactName = supplierAddDto.CompanyName,
                ContactTitle = supplierAddDto.ContactTitle,
                CreationDate = DateTime.Now,
                Country = supplierAddDto.Country,
                CreationUser = supplierAddDto.UserId,
                Fax = supplierAddDto.Fax,
                Phone = supplierAddDto.Phone,
                PostalCode = supplierAddDto.PostalCode,
                Region = supplierAddDto.Region

            };
        }

        public static Supplier ConvertSupplierToSupplierUpdateDto(this SupplierUpdateDto supplierUpdateDto)
        {
            return new Supplier()
            {
                    Address = supplierUpdateDto.Address,
                    City = supplierUpdateDto.City,
                    CompanyName = supplierUpdateDto.CompanyName,
                    ContactName = supplierUpdateDto.CompanyName,
                    ContactTitle = supplierUpdateDto.ContactTitle,
                    ModifyDate = Convert.ToDateTime(supplierUpdateDto.ChangeDate),
                    Country = supplierUpdateDto.Country,
                    ModifyUser = supplierUpdateDto.UserId,
                    Fax = supplierUpdateDto.Fax,
                    Phone = supplierUpdateDto.Phone,
                    PostalCode = supplierUpdateDto.PostalCode,
                    Region = supplierUpdateDto.Region,
            };
        }
    }
}
