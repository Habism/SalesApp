using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SalesApp.Sales.Api.Infrastructure.Data.Core
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        bool Exists(Expression<Func<TEntity, bool>> filter);

        List<TEntity> Get();

        TEntity GetById(int EntityId);
    }
}
