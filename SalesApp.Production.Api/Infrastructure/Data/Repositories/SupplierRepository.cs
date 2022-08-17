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
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        private readonly ILogger<SupplierRepository> logger;
        public SupplierRepository(ProductionContext context,
                                  ILogger<SupplierRepository> logger) : base(context)
        {
            this.logger = logger;
        }
        public async Task<SupplierModel> GetSupplierById(int supplierId)
        {
            SupplierModel model = new SupplierModel();

            try
            {
                var supplier = await base.GetById(supplierId);

                model.Supplierid = supplier.SupplierId;
                model.CompanyName = supplier.CompanyName;
                model.Address = supplier.Address;
                model.City = supplier.City;
                model.ContactName = supplier.ContactName;
                model.ContactTitle = supplier.ContactTitle;
                model.Country = supplier.Country;
                model.Fax = supplier.Fax;
                model.Phone = supplier.Phone;
                model.Region = supplier.Region;

            }
            catch (Exception ex)
            {
                model = null;
                logger.LogError("Error obteniendo el suplidor.", ex.ToString());
            }

            return model;
        }
        public async Task<List<SupplierModel>> GetSuppliers()
        {
            List<SupplierModel> suppliersList = new List<SupplierModel>();
            try
            {
                suppliersList = (await base.GetAll(su => !su.Deleted))
                    .Select(su => new SupplierModel()
                    {
                        Address = su.Address,
                        City = su.City,
                        CompanyName = su.CompanyName,
                        ContactName = su.ContactName,
                        ContactTitle = su.ContactTitle,
                        Country = su.Country,
                        Fax = su.Fax,
                        Phone = su.Phone,
                        PostalCode = su.PostalCode,
                        Region = su.Region,
                        Supplierid = su.SupplierId
                    }).ToList();
            }
            catch (Exception ex)
            {
                suppliersList = null;
                logger.LogError("Error obteniendo los suplidores.", ex.ToString());
            }
            return suppliersList;
        }

    }
}

