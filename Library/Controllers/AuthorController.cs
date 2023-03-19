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
                            AuthorId = a.Author_id,
                            FirstName = a.First_name,
                            LastName = a.Last_name
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
                    Author_id = Guid.NewGuid(),
                    First_name = model.FirstName,
                    Last_name = model.LastName
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
                                  join b in books on a.Author_id equals b.Author_id
                                  where a.Author_id == id
                                  select new AuthorsModel()
                                  {
                                      FirstName = a.First_name,
                                      LastName = a.Last_name,
                                      BookName = b.Name
                                  };
                if (authorTable != null)
                    return View(authorTable);
            }
            return NotFound();
        }
    }
}
