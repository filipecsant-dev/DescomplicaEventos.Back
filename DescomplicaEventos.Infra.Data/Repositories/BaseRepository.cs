using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DescomplicaEventos.Domain.Entities;
using DescomplicaEventos.Domain.Interfaces;
using DescomplicaEventos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DescomplicaEventos.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _DbSet;
        private readonly AppDbContext _context;
        protected BaseRepository(AppDbContext context)
        {
            _DbSet = context.Set<TEntity>();
            _context = context;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _DbSet.AsQueryable();

            if(filter != null)
                query = query
                        .Where(filter)
                        .AsNoTracking();

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(Guid id)
        {
            return await _DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _DbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            _DbSet.Update(entity);
            return entity;
        }

        public virtual async Task<TEntity> Delete(Guid id)
        {
            var entity = await _DbSet.FindAsync(id);
            if(entity != null)
            {
                entity.disabledEntity();
                await Update(entity);
                return entity;
            }
                
            return null;
        }
    }
}