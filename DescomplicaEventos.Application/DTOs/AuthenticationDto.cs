using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DescomplicaEventos.Application.DTOs
{
    public class AuthenticationDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}