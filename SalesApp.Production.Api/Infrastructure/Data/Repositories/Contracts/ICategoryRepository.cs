using SalesApp.Production.Api.Infrastructure.Data.Core;
using SalesApp.Production.Api.Infrastructure.Data.Entities;
using SalesApp.Production.Api.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Infrastructure.Data.Repositories.Contracts
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<List<CategoryModel>> GetCategories();

        Task<CategoryModel> GetCategoryById(int CategoryId);
    }
}
