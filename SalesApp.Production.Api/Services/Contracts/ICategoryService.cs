using System.Threading.Tasks;

namespace SalesApp.Production.Api.Services.Contracts
{
    public interface ICategoryService
    {
        Task<Services.Core.ServiceResponse> GetCategories();

       //Task<Services.Responses.CountryAddResponse> AddCategory(Dto.CategoryDto categoryDto);
    }
}
