using Library.BLL.Services;
using Library.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Library.API.Models;
using System;

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
        }
    }
}
