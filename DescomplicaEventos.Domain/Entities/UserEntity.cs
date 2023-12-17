using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DescomplicaEventos.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; private set; }
        public int Idade { get; private set; }

        public UserEntity(string name, int idade) : base()
        {
            Name = name;
            Idade = idade;
        }
    }
}