using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Dtos
{
    public class CategoryAddDto : BaseDto
    {
        [Required(ErrorMessage = "La categoria es requerida")]
        [StringLength(15, ErrorMessage = "Longitud invalidad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(200, ErrorMessage = "Logintud invalidad")]
        public string Description { get; set; }

    }
}
