using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService { get; set; }
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLogin userForLogin)
        {
            var userToLogin = _authService.Login(userForLogin);
            if(!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            var token = _authService.CreateAccessToken(userToLogin.Data);
            if(token.Success)
            {
                return Ok(token.Data);
            }
            return BadRequest(token.Message);

        }
        [HttpPost("register")]
        public IActionResult Register(UserForRegister userForRegister)
        {
            var CheckedUser = _authService.UserExists(userForRegister.Email);
            if(!CheckedUser.Success)
            {
                return BadRequest(CheckedUser.Message);
            }
            var RegisteredUser = _authService.Register(userForRegister);
           if(!RegisteredUser.Success)
            {
                return BadRequest(RegisteredUser.Message);
            }

            var Token = _authService.CreateAccessToken(RegisteredUser.Data);
            if(Token.Success)
            {
                return Ok(Token.Data);
            }
            return BadRequest(Token.Message);
           
        }
    }
}
