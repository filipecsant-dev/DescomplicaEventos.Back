using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DescomplicaEventos.API.Controllers.Shared;
using DescomplicaEventos.Application.DTOs;
using DescomplicaEventos.Application.Interfaces;
using DescomplicaEventos.Application.ViewModel;
using DescomplicaEventos.Application.ViewModel.Shared;
using DescomplicaEventos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DescomplicaEventos.API.Controllers
{
    [Route("v1/[controller]")]
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var retorno = await _service.GetAllAsync();
            return ResponseOk(retorno);   
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto userDto)
        {
            var user = await _service.CreateAsync(userDto, true);
            return ResponseCreated(user);
        }
    }
}