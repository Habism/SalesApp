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
        public static Category ConvertCategoryToCategorySaveDto(this CategoryAddDto categoryDto)
        {
            return new Category()
            {
                CreationDate = Convert.ToDateTime(categoryDto.ChangeDate),
                CreationUser = categoryDto.UserId,
                CategoryName = categoryDto.Name,
                Description = categoryDto.Description

            };
        }
    }
}
