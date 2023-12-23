using DescomplicaEventos.API.Controllers.Shared;
using DescomplicaEventos.Application.DTOs;
using DescomplicaEventos.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DescomplicaEventos.API.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAllAsync();
            return ResponseOk(result.Data);   
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto userDto)
        {
            var result = await _userService.CreateAsync(userDto, true);
            if(result.IsSuccess)
                return ResponseOk(result.Data);

            return ResponseBadRequest(result.Errors);
        }
    }
}