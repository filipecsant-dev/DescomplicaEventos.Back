using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DescomplicaEventos.Application.DTOs;
using DescomplicaEventos.Application.Services.Shared;
using DescomplicaEventos.Application.ViewModel;
using DescomplicaEventos.Domain.Entities;

namespace DescomplicaEventos.Application.Interfaces
{
    public interface IUserService
    {
        Task<ResultService<IEnumerable<UserDto>>> GetAllAsync(Expression<Func<User, bool>> filter = null);
        Task<ResultService<UserDto>> CreateAsync(UserDto dto, bool save = false);
    }
}