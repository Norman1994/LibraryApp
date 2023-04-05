using Library.BLL.Services;
using Library.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;
using Library.API.Models;

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

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(authorService.GetAuthors(0, 10));
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(Guid id)
        {
            return Ok(authorService.GetById(id));
        }

        [HttpPost("create")]
        public IActionResult Create(AuthorViewModel author)
        {
            return Ok();
        }

        [HttpPut("edit")]
        public IActionResult Edit(AuthorViewModel author)
        {
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }
    }
}
