using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DescomplicaEventos.Application.DTOs;
using DescomplicaEventos.Application.Interfaces;
using DescomplicaEventos.Application.ViewModel;
using DescomplicaEventos.Domain.Entities;
using DescomplicaEventos.Domain.Interfaces;

namespace DescomplicaEventos.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserVM>> GetAllAsync(Expression<Func<UserEntity, bool>> filter = null)
        {
            var entities = await _repository.GetAllAsync(filter);
            var retorno = _mapper.Map<IEnumerable<UserVM>>(entities);
            return retorno;
        }
        public async Task<UserVM> CreateAsync(UserDto dto, bool save = false)
        {
            var mapEntitie = _mapper.Map<UserEntity>(dto);
            var getPasswordHash = GetHashPasswordUser(mapEntitie, dto.Password);
            mapEntitie.ChangePassword(getPasswordHash.passwordHash, getPasswordHash.passwordSalt);
            var entity = await _repository.CreateAsync(mapEntitie, save);
            var retorno = _mapper.Map<UserVM>(entity);
            return retorno;
        }

        private (byte[] passwordHash, byte[] passwordSalt) GetHashPasswordUser(UserEntity user, string password)
        {
            using var hmac = new HMACSHA512();
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            byte[] passwordSalt = hmac.Key;

            return (passwordHash, passwordSalt);
        }
    }
}