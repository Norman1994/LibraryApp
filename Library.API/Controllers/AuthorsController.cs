using Library.BLL.Services;
using Library.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Library.API.Models;
using System;
using Library.BLL.Dto;

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
                var authors = mapper.Map<List<AuthorViewModel>>(authorService.GetAuthors(0, 10));
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
                var author = mapper.Map<AuthorViewModel>(authorService.GetById(authorId));
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
                AuthorDto author = mapper.Map<AuthorDto>(model);
                var result = authorService.Create(author);

                return Ok(result);
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
                AuthorDto editAuthor = mapper.Map<AuthorDto>(model);
                var result = authorService.Update(editAuthor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var result = authorService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return BadRequest();
            }
        }
    }
}
