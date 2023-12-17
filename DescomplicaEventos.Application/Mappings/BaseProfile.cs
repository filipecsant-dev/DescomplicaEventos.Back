using AutoMapper;
using DescomplicaEventos.Application.ViewModel.Shared;

namespace DescomplicaEventos.Application.Mappings
{
    public abstract class BaseProfile<TDto, TEntity, TViewModel> : Profile
    {
        public BaseProfile()
        {
            CreateMap<TDto, TEntity>();
            CreateMap<TEntity, BaseVM<TViewModel>>();
        }
    }
}