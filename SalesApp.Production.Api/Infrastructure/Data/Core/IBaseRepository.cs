using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Infrastructure.Data.Core
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);

        Task Update(TEntity entity);

        Task Remove(TEntity entity);

        bool Exists(Expression<Func<TEntity, bool>> filter);

        Task<List<TEntity>> Get();

        Task<TEntity> GetById(int EntityId);

        Task<TEntity> GetByEntity(Expression<Func<TEntity, bool>> filter);
    }
}
