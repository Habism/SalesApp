using SalesApp.Production.Api.Dtos.Supplier;
using SalesApp.Production.Api.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Services.Contracts
{
   public  interface ISupplierService
    {
        Task<ServiceResponse> GetSuppliers();
        Task<ServiceResponse> GeSupplierById(int supllierId);
        Task<ServiceResponse> SaveSupplier(SupplierAddDto supplierAddDto);
        Task<ServiceResponse> UpdateSupplier(SupplierUpdateDto supplierUpdateDto);
        //Task<ServiceResponse> RemoveSupplier(CategoryRemoveDto categoryRemove);
    }
}
