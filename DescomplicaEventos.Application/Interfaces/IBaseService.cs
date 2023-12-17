using System.Linq.Expressions;
using DescomplicaEventos.Application.ViewModel.Shared;
using DescomplicaEventos.Domain.Entities;

namespace DescomplicaEventos.Application.Interfaces
{
    public interface IBaseService<TDto, TEntity, TViewModel> where TEntity : BaseEntity 
    {
        Task<BaseVM<TViewModel>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<BaseVM<TViewModel>> GetAsync(Guid id);
        Task<BaseVM<TViewModel>> CreateAsync(TDto dto, bool save = false);
        Task<BaseVM<TViewModel>> CreateRangeAsync(IEnumerable<TDto> dto, bool save = false);
        Task UpdateAsync(TDto dto, bool save = false);
        Task DeleteAsync(Guid id, bool save = false);
    }
}