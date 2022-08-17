using Microsoft.AspNetCore.Mvc;
using SalesApp.Production.Api.Dtos.Supplier;
using SalesApp.Production.Api.Services.Contracts;
using SalesApp.Production.Api.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }
        [HttpGet("GetSuppliers")]
        public async Task<ActionResult<ServiceResponse>> GetSuppliers()
        {
            var response = await this.supplierService.GetSuppliers();
            return Ok(response);
        }
        [HttpGet("GetSupplierById/{Id}")]
        public async Task<ActionResult<ServiceResponse>> GetSuppliers(int Id)
        {
            var response = await this.supplierService.GeSupplierById(Id);
            return Ok(response);
        }

        [HttpPost("SaveSupplier")]
        public async Task<ActionResult<ServiceResponse>> SaveSupplier(SupplierAddDto supplierAddDto)
        {
            var response = await supplierService.SaveSupplier(supplierAddDto);
            return Ok(response);
        }
        [HttpPost("UpdateSupplier")]
        public async Task<ActionResult<ServiceResponse>> UpdateSupplier(SupplierUpdateDto supplierUpdateDto)
        {
            var response = await supplierService.UpdateSupplier(supplierUpdateDto);
            return Ok(response);
        }

    }
}
