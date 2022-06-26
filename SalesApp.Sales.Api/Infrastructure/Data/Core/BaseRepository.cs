using Microsoft.EntityFrameworkCore;
using SalesApp.Sales.Api.Infrastructure.Context;
using SalesApp.Sales.Api.Infrastructure.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SalesApp.Sales.Api.Infrastructure.Data.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly SalesContext _context;

        private DbSet<TEntity> _entities;

        public BaseRepository(SalesContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return _entities.Any(filter);
        }

        public List<TEntity> Get()
        {
            return _entities.ToList();
        }

        public TEntity GetById(int EntityId)
        {
            return _entities.Find(EntityId);
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();
        }
    }
}
