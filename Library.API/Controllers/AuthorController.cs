using System.Collections.Generic;
using Library.BLL.Services;
using Library.DAL.Entities;
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
        public List<Author> Get()
        {
            return authorService.GetAuthors(0, 10);
        }
    }
}
