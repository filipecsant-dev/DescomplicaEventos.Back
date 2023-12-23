using AutoMapper;
using DescomplicaEventos.Application.DTOs;
using DescomplicaEventos.Domain.Entities;

namespace DescomplicaEventos.Application.Mappings
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<UserDto, User>();
        }
    }
}