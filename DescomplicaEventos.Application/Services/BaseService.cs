using AutoMapper;
using DescomplicaEventos.Application.Interfaces;
using DescomplicaEventos.Application.ViewModel.Shared;
using DescomplicaEventos.Domain.Entities;
using DescomplicaEventos.Domain.Interfaces;

namespace DescomplicaEventos.Application.Services
{
    public abstract class BaseService<TDto, TEntity, TViewModel> : IBaseService<TDto, TEntity, TViewModel> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        protected BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<BaseVM<TViewModel>> GetAllAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null)
        {
            var result = await _repository.GetAllAsync(filter);
            return _mapper.Map<BaseVM<TViewModel>>(result);
        }

        public virtual async Task<BaseVM<TViewModel>> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);
            return _mapper.Map<BaseVM<TViewModel>>(result);
        }
    
        public virtual async Task<BaseVM<TViewModel>> CreateAsync(TDto dto, bool save = false)
        {
            var mapEntity = _mapper.Map<TEntity>(dto);
            var result = await _repository.CreateAsync(mapEntity, save);
            return _mapper.Map<BaseVM<TViewModel>>(result);
        }

        public virtual async Task<BaseVM<TViewModel>> CreateRangeAsync(IEnumerable<TDto> dto, bool save = false)
        {
            var mapEntity = _mapper.Map<IEnumerable<TEntity>>(dto);
            var result = await _repository.CreateRangeAsync(mapEntity, save);
            return _mapper.Map<BaseVM<TViewModel>>(result);
        }

        public virtual async Task UpdateAsync(TDto dto, bool save = false)
        {
            var mapEntity = _mapper.Map<TEntity>(dto);
            await _repository.UpdateAsync(mapEntity, save);
        }

        public virtual async Task DeleteAsync(Guid id, bool save = false)
        {
            await _repository.DeleteAsync(id, save);
        }
    }
}