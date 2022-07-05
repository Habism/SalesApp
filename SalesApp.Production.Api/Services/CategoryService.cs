using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalesApp.Production.Api.Dtos;
using SalesApp.Production.Api.Infrastructure.Data.Entities;
using SalesApp.Production.Api.Infrastructure.Data.Exceptions;
using SalesApp.Production.Api.Infrastructure.Data.Repositories.Contracts;
using SalesApp.Production.Api.Services.Contracts;
using SalesApp.Production.Api.Services.Core;
using SalesApp.Production.Api.Services.Extensions;
using SalesApp.Production.Api.Services.Responses;
using System;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ILogger<CategoryService> logger;
        private readonly ICategoryRepository categoryRepository;
        private readonly IConfiguration configuration;

        public CategoryService(ILogger<CategoryService> logger, 
                            ICategoryRepository categoryRepository, 
                            IConfiguration configuration)
        {
            this.logger = logger;   
            this.categoryRepository = categoryRepository;
            this.configuration = configuration;
        }

        public async Task<ServiceResponse> GetCategories()
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                response.Data = await this.categoryRepository.GetCategories();
                response.Message = this.configuration["MensajesCategory:CategoriasConsulta"];
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = this.configuration["MensajesCategory:MensajeError"];
                this.logger.LogError(response.Message, ex.ToString());
            }
            return response;
        }

        public async Task<ServiceResponse> GetCategoryById(int CategoryId)
        {

            ServiceResponse response = new ServiceResponse();

            try
            {
                response.Data = await categoryRepository.GetCategoryById(CategoryId);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error obteniendo las categorias";
                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

        public async Task<ServiceResponse> SaveCategory()
        {
            ServiceResponse response = new ServiceResponse();
            try
            {

            }
            catch (CategoryException caex)
            {
                response.Message = caex.Message;
                response.Success = false;
            }
            catch (Exception ex)
            {
                throw;
            }

            return response;
        }
    }
}
