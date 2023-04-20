using System;
using Library.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Library.API.Models;
using Library.BLL.Dto;

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
                var books = mapper.Map<List<BookViewModel>>(bookService.GetAll(0, 10));
                return Ok(books);
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
                var bookInfo = mapper.Map<BookViewModel>(bookService.GetById(id));
                return Ok(bookInfo);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return BadRequest();
            }
        }

        [HttpPost("addbook")]
        public ActionResult AddBook(BookCreateUpdateModel newBook)
        {
            try
            {
                BookDto book = mapper.Map<BookDto>(newBook);
                bool result = bookService.Create(book);

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return BadRequest();
            }
        }

        [HttpPost("updatebook")]
        public ActionResult UpdateBook(BookCreateUpdateModel updatedBook)
        {
            try
            {
                BookDto book = mapper.Map<BookDto>(updatedBook);
                bool result = bookService.Update(book);

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
