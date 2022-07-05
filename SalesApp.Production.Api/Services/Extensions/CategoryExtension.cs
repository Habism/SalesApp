using SalesApp.Production.Api.Dtos;
using SalesApp.Production.Api.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Services.Extensions
{
    public static class CategoryExtension
    {
        public static Category ConvertCategoryToCategorySaveDto(this CategorySaveDto categoryDto)
        {
            return new Category()
            {
                CategoryName = categoryDto.CategoryName,
                CreationUser = categoryDto.UserId,
                CreationDate = Convert.ToDateTime(categoryDto.ChangeDate)

            };
        }
    }
}
