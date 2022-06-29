using SalesApp.Production.Api.Infrastructure.Data.Context;
using SalesApp.Production.Api.Infrastructure.Data.Core;
using SalesApp.Production.Api.Infrastructure.Data.Entities;
using SalesApp.Production.Api.Infrastructure.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Infrastructure.Data.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ProductionContext context) : base(context)
        {

        }
    }
}
