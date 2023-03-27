using System;
using Library.BLL.Services;
using Library.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

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

        [HttpPost]
        public bool Post (UserInfo user)
        {
            return userService.Create(user);
        }

        [HttpPut()]
        public bool Put (UserInfo user)
        {
            return userService.Update(user);
        }

        [HttpGet()]
        public IEnumerable<UserInfo> GetAll(int offset = 0, int limit = 10)
        {
            return userService.GetAll(offset, limit);
        }

        [HttpGet("getuser")]
        public UserInfo GetUser(Guid id)
        {
            return userService.GetById(id);
        }
    }
}
