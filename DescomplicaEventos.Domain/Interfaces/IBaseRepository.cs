using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DescomplicaEventos.Domain.Entities;

namespace DescomplicaEventos.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetAsync(Guid id);
        Task<TEntity> CreateAsync(TEntity entity, bool save = false);
        Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities, bool save = false);
        Task UpdateAsync(TEntity entity, bool save = false);
        Task DeleteAsync(Guid id, bool save = false);
    }
}