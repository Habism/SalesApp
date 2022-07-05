using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Dtos
{
    public class BaseDto
    {
        public int UserId { get; set; }
        public string ChangeDate { get; set; }
    }
}
