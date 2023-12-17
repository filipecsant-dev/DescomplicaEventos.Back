using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DescomplicaEventos.Application.DTOs;
using DescomplicaEventos.Application.ViewModel;
using DescomplicaEventos.Domain.Entities;

namespace DescomplicaEventos.Application.Mappings
{
    public class DomainMapperProfile : Profile
    {
        public DomainMapperProfile()
        {
            CreateMap<UserDto, UserEntity>();
            CreateMap<UserEntity, UserVM>();
        }
    }
}