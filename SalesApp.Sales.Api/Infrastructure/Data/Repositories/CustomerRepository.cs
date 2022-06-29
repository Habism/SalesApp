using SalesApp.Sales.Api.Infrastructure.Data.Context;
using SalesApp.Sales.Api.Infrastructure.Data.Core;
using SalesApp.Sales.Api.Infrastructure.Data.Entities;
using SalesApp.Sales.Api.Infrastructure.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Sales.Api.Infrastructure.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SalesContext context) : base(context)
        {

        }
    }
}
