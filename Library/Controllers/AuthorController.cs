using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                            AuthorId = a.AuthorId,
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
        public IActionResult AddAuthor(AuthorsModel model)
        {
            if (ModelState.IsValid)
            {
                Authors author = db.Author.FirstOrDefault();

                author = new Authors
                {
                    AuthorId = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName
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
                                  join b in books on a.AuthorId equals b.AuthorId
                                  where a.AuthorId == id
                                  select new AuthorsModel()
                                  {
                                      FirstName = a.FirstName,
                                      LastName = a.LastName,
                                      BookName = b.Name
                                  };
                if (authorTable != null)
                    return View(authorTable);
            }
            return NotFound();
        }
    }
}
