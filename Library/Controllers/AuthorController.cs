using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class AuthorController : Controller
    {
        private ApplicationContext db;

        public AuthorController(ApplicationContext context)
        {
            db = context;
        }
        // GET: AuthorController
        public IActionResult AuthorIndex()
        {
            var authors = db.Author.ToList();
            var table = from a in authors
                        select new AuthorsModel()
                        {
                            AuthorId = a.author_id,
                            FirstName = a.first_name,
                            LastName = a.last_name
                        };

            return View(table);
        }

        public IActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAuthor(AuthorsModel model)
        {
            if (ModelState.IsValid)
            {
                Authors author = db.Author.FirstOrDefault();

                author = new Authors
                {
                    author_id = Guid.NewGuid(),
                    first_name = model.FirstName,
                    last_name = model.LastName
                };

                db.Author.Add(author);
                db.SaveChanges();
                return RedirectToAction("AuthorIndex");

            }
            return NotFound();
        }

        public IActionResult AuthorDetails(Guid id)
        {
            if (id != null)
            {
                var authors = db.Author.ToList();
                var books = db.Book.ToList();

                var authorTable = from a in authors
                                  join b in books on a.author_id equals b.author_id
                                  where a.author_id == id
                                  select new AuthorsModel()
                                  {
                                      FirstName = a.first_name,
                                      LastName = a.last_name,
                                      BookName = b.name
                                  };
                if (authorTable != null)
                    return View(authorTable);
            }
            return NotFound();
        }
    }
}
