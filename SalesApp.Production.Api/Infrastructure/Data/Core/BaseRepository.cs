using Microsoft.EntityFrameworkCore;
using SalesApp.Production.Api.Infrastructure.Data.Context;
using SalesApp.Production.Api.Infrastructure.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SalesApp.Production.Api.Infrastructure.Data.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ProductionContext _context;

        private DbSet<TEntity> _entities;

        public BaseRepository(ProductionContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public async virtual Task Add(TEntity entity)
        {
            _entities.Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetByEntity(Expression<Func<TEntity, bool>> filter)
        {
            return await _entities.FirstOrDefaultAsync(filter);
        }
        public async virtual Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            return await _entities.AnyAsync(filter);
        }

        public async Task<List<TEntity>> Get()
        {
            return await _entities.ToListAsync();
        }

        public async Task<TEntity> GetById(int EntityId)
        {
            return await _entities.FindAsync(EntityId);
        }

        public async Task Remove(TEntity entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _entities.Update(entity);
           await _context.SaveChangesAsync();
        }
    }
}
