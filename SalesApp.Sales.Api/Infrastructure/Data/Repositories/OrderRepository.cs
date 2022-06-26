using SalesApp.Sales.Api.Infrastructure.Context;
using SalesApp.Sales.Api.Infrastructure.Data.Core;
using SalesApp.Sales.Api.Infrastructure.Data.Entities;
using SalesApp.Sales.Api.Infrastructure.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Sales.Api.Infrastructure.Data.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(SalesContext context) : base(context)
        {

        }
    }
}
