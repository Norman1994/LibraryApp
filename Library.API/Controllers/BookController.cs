using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.BLL.Services;
using Library.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> logger;

        private readonly IBookService bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            this.logger = logger;
            this.bookService = bookService;
        }

        [HttpGet]
        public List<Book> Get()
        {
            return bookService.GetAll(0, 10);
        }
    }
}
