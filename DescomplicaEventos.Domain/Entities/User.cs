using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace DescomplicaEventos.Domain.Entities
{
    public class User : BaseEntity
    {
        public string  Email { get; private set; }
        public string Name { get; private set; }
        public int Idade { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }

        public User(string email, string name, int idade)
        {
            Email = email;
            Name = name;
            Idade = idade;
        }

        public void ChangePassword(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}