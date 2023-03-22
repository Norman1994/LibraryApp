using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("authenticate")]
        public IActionResult Authenticate()
        {
            return null;
        }

        [HttpPost("register")]
        public IActionResult Register()
        {
            return Ok();
        }

        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}
