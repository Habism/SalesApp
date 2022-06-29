using Microsoft.Extensions.Logging;
using SalesApp.Production.Api.Infrastructure.Data.Repositories.Contracts;

namespace SalesApp.Production.Api.Services
{
    public class CategoryService
    {
        private readonly ILogger<CategoryService> logger;
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ILogger<CategoryService> logger, ICategoryRepository categoryRepository)
        {
            this.logger = logger;   
            this.categoryRepository = categoryRepository;   
        }
    }
}
