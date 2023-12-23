using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using DescomplicaEventos.Application.DTOs;
using DescomplicaEventos.Application.DTOs.Validations;
using DescomplicaEventos.Application.Interfaces;
using DescomplicaEventos.Application.Services.Shared;
using DescomplicaEventos.Domain.Entities;
using DescomplicaEventos.Domain.Interfaces;

namespace DescomplicaEventos.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<IEnumerable<UserDto>>> GetAllAsync(Expression<Func<User, bool>> filter = null)
        {
            var entities = await _userRepository.GetAllAsync(filter);
            return ResultService<IEnumerable<UserDto>>.Ok(_mapper.Map<IEnumerable<UserDto>>(entities));
        }
        
        public async Task<ResultService<UserDto>> CreateAsync(UserDto userDto, bool save = false)
        {
            if(userDto == null)
                return ResultService<UserDto>.Fail("Dados devem ser informado!");

            var entity = _mapper.Map<User>(userDto);

            var validation = new UserDtoValidator().Validate(userDto);
            if(!validation.IsValid)
                return ResultService<UserDto>.RequestError("Problema encontrados nos dados informados!", validation);

            var getPasswordHash = GetHashPasswordUser(entity, userDto.Password);
            entity.ChangePassword(getPasswordHash.passwordHash, getPasswordHash.passwordSalt);
            var data = await _userRepository.CreateAsync(entity, save);

            return ResultService<UserDto>.Ok(_mapper.Map<UserDto>(data));
        }

        private (byte[] passwordHash, byte[] passwordSalt) GetHashPasswordUser(User user, string password)
        {
            using var hmac = new HMACSHA512();
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            byte[] passwordSalt = hmac.Key;

            return (passwordHash, passwordSalt);
        }
    }
}