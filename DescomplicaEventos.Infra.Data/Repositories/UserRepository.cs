using DescomplicaEventos.Domain.Entities;
using DescomplicaEventos.Domain.Interfaces;
using DescomplicaEventos.Infra.Data.Context;
using DescomplicaEventos.Infra.Data.Repositories.Shared;

namespace DescomplicaEventos.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}