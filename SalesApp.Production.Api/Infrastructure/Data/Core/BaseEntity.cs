using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Infrastructure.Data.Core
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.CreationDate = DateTime.Now;
            this.Deleted = false;
        }

        [Column("creation_date", TypeName = "DateTime")]
        public DateTime CreationDate { get; set; }

        [Column("creation_user", TypeName = "Int")]
        public int CreationUser { get; set; }

        [Column("modify_date", TypeName = "DateTime")]
        public DateTime? ModifyDate { get; set; }

        [Column("modify_user", TypeName = "Int")]
        public int? ModifyUser { get; set; }

        [Column("delete_user", TypeName = "Int")]
        public int? DeleteUser { get; set; }

        [Column("delete_date", TypeName = "DateTime")]
        public DateTime? DeleteDate { get; set; }

        public bool Deleted { get; set; }
    }
}
