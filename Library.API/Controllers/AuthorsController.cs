using Library.BLL.Services;
using Library.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly ILogger<AuthorsController> logger;

        private readonly IAuthorService authorService;
        public AuthorsController(ILogger<AuthorsController> logger, IAuthorService authorService)
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
