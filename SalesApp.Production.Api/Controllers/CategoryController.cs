using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesApp.Production.Api.Services.Contracts;
using SalesApp.Production.Api.Services.Core;

namespace SalesApp.Production.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("GetCategories")]
        public async Task<ActionResult<ServiceResponse>> GetCategories()
        {
            ServiceResponse response = new ServiceResponse();

            response = await categoryService.GetCategories();

            return Ok(response);
        }

        [HttpGet("GetCategoryById")]
        public async Task<ActionResult<ServiceResponse>> GetCategoryById(int CategoryId)
        {
            ServiceResponse response = new ServiceResponse();

            response = await categoryService.GetCategoryById(CategoryId);

            return Ok(response);
        }
    }
}
