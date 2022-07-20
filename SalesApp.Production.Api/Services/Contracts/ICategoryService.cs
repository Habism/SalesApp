using SalesApp.Production.Api.Dtos;
using SalesApp.Production.Api.Services.Core;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Services.Contracts
{
    public interface ICategoryService
    {
        Task<ServiceResponse> GetCategories();

        Task<ServiceResponse> GetCategoryById(int CategoryId);

        Task<ServiceResponse> SaveCategory(CategoryAddDto categoryAdd);

        Task<ServiceResponse> UpdateCountry(CategoryUpdateDto categoryUpdate);

        Task<ServiceResponse> RemoveCategory(CategoryRemoveDto categoryRemove);
    }
}
