using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DescomplicaEventos.Domain.Account;
using DescomplicaEventos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DescomplicaEventos.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthenticateService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            var user = await _context.users.AsNoTracking().FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            if(user == null)
                return false;

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for(int x = 0; x < computedHash.Length; x++)
            {
                if(computedHash[x] != user.PasswordHash[x])
                    return false;
            }

            return true;
        }

        public async Task<bool> UserExists(string email)
        {
            return await _context.users.AsNoTracking().AnyAsync(x => x.Email.ToLower() == email.ToLower());
        }

        public string GenerateToken(string email)
        {
            var id = GetIdUserByEmail(email);

            var claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("email", email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(24);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Guid GetIdUserByEmail(string email)
        {
            return _context.users.AsNoTracking().FirstOrDefault(x => x.Email.ToLower() == email.ToLower()).Id;
        }
    }
}