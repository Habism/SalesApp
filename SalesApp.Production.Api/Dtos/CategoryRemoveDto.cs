using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Dtos
{
    public class CategoryRemoveDto : BaseDto
    {
        [Required(ErrorMessage = "El Id de la categoria es requerido")]
        public int Id { get; set; }

        public int RemoveUser { get; set; }
    }
}
