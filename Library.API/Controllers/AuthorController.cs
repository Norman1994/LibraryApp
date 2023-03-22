using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> logger;

        private readonly IAuthorService authorService;
        public AuthorController(ILogger<AuthorController> logger, IAuthorService authorService)
        {
            this.logger = logger;
            this.authorService = authorService;
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            return null;
        }
    }
}
