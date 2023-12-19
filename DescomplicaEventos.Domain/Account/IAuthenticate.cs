using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DescomplicaEventos.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task<bool> UserExists(string email);
        public string GenerateToken(string email);
    }
}