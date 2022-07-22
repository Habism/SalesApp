using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesApp.Production.Api.Dtos;
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

        [HttpPost("SaveCategory")]
        public async Task<ActionResult<ServiceResponse>> SaveCategory(CategoryAddDto categoryAddDto)
        {
            ServiceResponse response = new ServiceResponse();

            response = await categoryService.SaveCategory(categoryAddDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("UpdateCategory")]
        public async Task<ActionResult<ServiceResponse>> UpdateCategory(CategoryUpdateDto countryUpdateDto)
        {
            ServiceResponse response = new ServiceResponse();

            response = await categoryService.UpdateCategory(countryUpdateDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("RemoveCategory")]
        public async Task<ActionResult<ServiceResponse>> RemoveCategory(CategoryRemoveDto categoryRemoveDto)
        {
            ServiceResponse response = new ServiceResponse();

            response = await categoryService.RemoveCategory(categoryRemoveDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
