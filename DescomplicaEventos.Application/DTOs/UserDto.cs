using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DescomplicaEventos.Application.DTOs
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int Idade { get; set; }
        [NotMapped]
        public string Password { get; set; }
    }
}