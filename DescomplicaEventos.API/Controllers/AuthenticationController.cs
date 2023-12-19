using DescomplicaEventos.API.Controllers.Shared;
using DescomplicaEventos.Application.DTOs;
using DescomplicaEventos.Application.ViewModel;
using DescomplicaEventos.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace DescomplicaEventos.API.Controllers
{
    [Route("v1/[controller]")]
    public class AuthenticationController : ApiControllerBase
    {
        private readonly IAuthenticate _authenticateService;
        public AuthenticationController(IAuthenticate authenticateService)
        {
            _authenticateService = authenticateService;
        } 

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationDto authenticationDto)
        {
            var userExists = await _authenticateService.UserExists(authenticationDto.Email);
            if(!userExists)
                return ResponseNotFound();

            var result = await _authenticateService.AuthenticateAsync(authenticationDto.Email, authenticationDto.Password);
            if(!result)
                return ResponseUnauthorized();

            var token = _authenticateService.GenerateToken(authenticationDto.Email);

            return ResponseOk(new AuthenticationVM { Token = token });
        }
    }
}