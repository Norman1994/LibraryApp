using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.BLL.Services;
using Library.DAL;
using Library.DAL.Entities;
using Library.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class AuthorController : Controller
    {
        private ApplicationContext db;
        private readonly IAuthorService authorService;

        public AuthorController(ApplicationContext context, IAuthorService authorService)
        {
            db = context;
            this.authorService = authorService;
        }
        // GET: AuthorController
        public IActionResult AuthorIndex()
        {
            var authors = authorService.GetAuthors(0, 10);
            var table = from a in authors
                        select new AuthorViewModel()
                        {
                            AuthorId = a.Id,
                            FirstName = a.FirstName,
                            LastName = a.LastName
                        };

            return View(table);
        }

        public IActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAuthor(AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Author author = new Author
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                authorService.Create(author);
                return RedirectToAction("AuthorIndex");

            }
            return NotFound();
        }

        public IActionResult AuthorDetails(Guid id)
        {
            if (id != null)
            {
                var authors = db.Authors.ToList();
                var books = db.Books.ToList();

                var authorTable = from a in authors
                                  join b in books on a.Id equals b.AuthorId
                                  where a.Id == id
                                  select new AuthorViewModel()
                                  {
                                      FirstName = a.FirstName,
                                      LastName = a.LastName,
                                  };
                if (authorTable != null)
                    return View(authorTable);
            }
            return NotFound();
        }
    }
}
