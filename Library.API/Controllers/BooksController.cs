﻿using System;
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
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> logger;

        private readonly IBookService bookService;

        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            this.logger = logger;
            this.bookService = bookService;
        }

        [HttpGet]
        public List<Book> Get()
        {
            try
            {
                return bookService.GetAll(0, 10);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
