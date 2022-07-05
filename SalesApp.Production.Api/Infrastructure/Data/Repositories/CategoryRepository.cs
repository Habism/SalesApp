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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

        private readonly ILogger<CategoryRepository> logger;

        public CategoryRepository(ProductionContext context, ILogger<CategoryRepository> logger) : base(context)
        {
            this.logger = logger;
        }

        public async Task<List<CategoryModel>> GetCategories()
        {
            List<CategoryModel> categories = new List<CategoryModel>();
            try
            {
                categories = (await base.Get())
                                        .Where(ca => !ca.Deleted)
                                        .Select(ca => new CategoryModel()
                                        {
                                            CategoryId = ca.CategoryId,
                                            CategoryName = ca.CategoryName,
                                            Description = ca.Description,
                                            CreationDate = ca.CreationDate

                                        }).ToList();
            }
            catch (Exception ex)
            {

                this.logger.LogError("error al obtener las categorias.", ex.ToString());
            }

            return categories;
        }

        public async Task<CategoryModel> GetCategoryById(int CategoryId)
        {
             CategoryModel categoryModel = new CategoryModel();

            try
            {
                var category = (await base.GetById(CategoryId));

                categoryModel.CategoryId = category.CategoryId;
                categoryModel.CategoryName = category.CategoryName;
                categoryModel.Description = category.Description;
                categoryModel.CreationDate = category.CreationDate;
            }
            catch (Exception ex) 
            {

                this.logger.LogError("error al obtener la categoria por el Id.", ex.ToString());
            }

            return categoryModel;
        }
    }
}
