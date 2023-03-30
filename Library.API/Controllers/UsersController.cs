using System;
using Library.BLL.Dto;
using Library.BLL.Services;
using Library.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace Library.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> logger;

        private readonly IUserService userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register (UserInfo user)
        {
            string errorMessage = "";
            AuthenticateResponse response = userService.Register(user, ref errorMessage);
            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(AuthenticateRequest model)
        {
            var response = userService.Authenticate(model);

            if(response is null)
            {
                return BadRequest(new { message = "Неверный логин и/или пароль" });
            }
            return Ok(response);
        }

        [HttpPut()]
        public bool Put (UserInfo user)
        {
            return userService.Update(user);
        }

        [HttpGet()]
        [Authorize(Roles = "admin")]
        public IEnumerable<UserInfo> GetAll (int offset = 0, int limit = 10)
        {
            return userService.GetAll(offset, limit);
        }

        [HttpGet("getuser")]
        public UserInfo GetUser (Guid id)
        {
            return userService.GetById(id);
        }
    }
}
