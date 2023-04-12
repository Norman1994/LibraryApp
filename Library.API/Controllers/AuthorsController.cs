using Library.BLL.Services;
using Library.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
<<<<<<< Updated upstream
using System;
using Library.API.Models;
=======
using AutoMapper;
using Library.API.Models;
using System;
>>>>>>> Stashed changes

namespace Library.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly ILogger<AuthorsController> logger;

        private readonly IAuthorService authorService;

        private readonly IMapper mapper;

        public AuthorsController(ILogger<AuthorsController> logger, IAuthorService authorService, IMapper mapper)
        {
            this.logger = logger;
            this.authorService = authorService;
            this.mapper = mapper;
        }

<<<<<<< Updated upstream
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
=======
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var authors = mapper.Map<List<AuthorModel>>(authorService.GetAuthors(0, 10));
                return Ok(authors);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return BadRequest();
            }
        }

        [HttpGet("getbyid")]
        public ActionResult GetById(Guid authorId)
        {
            try
            {
                var author = mapper.Map<AuthorModel>(authorService.GetById(authorId));
                return Ok(author);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return BadRequest();
            }
        }

        [HttpPost("addauthor")]
        public ActionResult AddAuthor([FromBody]AuthorModel model)
        {
            try
            {
                Author author = new Author
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                var newAuthor = mapper.Map<bool>(authorService.Create(author));
                return Ok(newAuthor);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return BadRequest();
            }
        }

        [HttpPost("editauthor")]
        public ActionResult EditAuthor([FromBody]AuthorModel model)
        {
            try
            {
                Author author = new Author
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                var newAuthor = mapper.Map<bool>(authorService.Update(author));
                return Ok(newAuthor);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return BadRequest();
            }
>>>>>>> Stashed changes
        }
    }
}
