using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DescomplicaEventos.Application.DTOs;
using DescomplicaEventos.Application.ViewModel;
using DescomplicaEventos.Domain.Entities;

namespace DescomplicaEventos.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserVM>> GetAllAsync(Expression<Func<UserEntity, bool>> filter = null);
        Task<UserVM> CreateAsync(UserDto dto, bool save = false);
    }
}