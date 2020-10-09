using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectV2.Data.Interfaces;
using ProjectV2.DTOs;
using ProjectV2.Models;

namespace ProjectV2.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterDTO userRegisterDTO)
        {
            userRegisterDTO.Username = userRegisterDTO.Username.ToLower();

            if (_authRepository.UserExists(userRegisterDTO.Username))
                return BadRequest("Username already exists!");

            var studentToCreate = new Users
            {
                Firstname = userRegisterDTO.Firstname,
                Lastname = userRegisterDTO.Lastname,
                Username = userRegisterDTO.Username,
                Group = userRegisterDTO.Group,
                Email = userRegisterDTO.Email
            };

            var createdStudent = _authRepository.Register(studentToCreate, userRegisterDTO.Password);
            return StatusCode(201);
        }
    }
}