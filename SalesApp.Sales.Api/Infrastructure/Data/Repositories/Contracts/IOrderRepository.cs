using SalesApp.Sales.Api.Infrastructure.Data.Core;
using SalesApp.Sales.Api.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Sales.Api.Infrastructure.Data.Repositories.Contracts
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
    }
}
