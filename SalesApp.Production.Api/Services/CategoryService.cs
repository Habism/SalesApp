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
                response.Data = await categoryRepository.GetByEntity(ca => ca.CategoryId == CategoryId
                                                                    && !ca.Deleted);
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


        public async Task<ServiceResponse> SaveCategory(CategoryAddDto categoryAdd)
        {
            ServiceResponse response = new ServiceResponse();
            try
            {
                Category newCategory = categoryAdd.ConvertCategoryToCategorySaveDto();

                await categoryRepository.Add(newCategory);

                response.Message = configuration["MensajesCategory:MensajeSave"];
            }
            catch (CategoryException caex)
            {
                response.Message = caex.Message;
                response.Success = false;
            }
            catch (Exception ex)
            {
                response.Message = configuration["MensajesCategory:MensajeSave"];
                response.Success = false;
                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

        public async Task<ServiceResponse> UpdateCategory(CategoryUpdateDto categoryUpdate)
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                Category category = await categoryRepository.GetById(categoryUpdate.Id);

                if (category != null)
                {
                    category.CategoryName = categoryUpdate.Name;
                    category.Description = categoryUpdate.Description;
                    category.ModifyDate = DateTime.Now;
                    category.ModifyUser = categoryUpdate.UserId;

                    await categoryRepository.Update(category);

                    response.Message = configuration["MensajesCategory:MensajeSave"];
                }
                else
                {
                    response.Success = false;
                    response.Message = configuration["MensajesCategory:MensajeNotFound"];
                }

            }
            catch (Exception ex)
            {
                response.Message = configuration["MensajesCategory:ErrorSaving"];
                response.Success = false;
                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

        public async Task<ServiceResponse> RemoveCategory(CategoryRemoveDto categoryRemove)
        {
            ServiceResponse response = new ServiceResponse();

            try
            {

                Category category = await categoryRepository.GetById(categoryRemove.Id);

                if (category != null)
                {
                    category.Deleted = true;
                    category.DeleteUser = categoryRemove.RemoveUser;
                    category.DeleteDate = DateTime.Now;
                    await categoryRepository.Update(category);

                    response.Message = configuration["MensajesCategory:MensajeRemove"];
                }
                else
                {
                    response.Success = false;
                    response.Message = configuration["MensajesCategory:MensajeNotFound"];
                }

            }
            catch (Exception ex)
            {
                response.Message = configuration["MensajesCategory:ErrorRemoving"];
                response.Success = false;
                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

    }
}
