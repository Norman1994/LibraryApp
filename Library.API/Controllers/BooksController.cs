using System;
using Library.BLL.Services;
using Library.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Library.API.Models;

namespace Library.API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> logger;

        private readonly IBookService bookService;

        private readonly IMapper mapper;

        public BooksController(ILogger<BooksController> logger, IBookService bookService, IMapper mapper)
        {
            this.logger = logger;
            this.bookService = bookService;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var users = mapper.Map<List<BookAuthorModel>>(bookService.GetAll(0, 10));
                return Ok(users);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return BadRequest();
            }
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(bookService.GetById(id));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return BadRequest();
            }
        }
    }
}
