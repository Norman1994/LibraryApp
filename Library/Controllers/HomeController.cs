using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;

        public HomeController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var authors = db.Author.ToList();
            var books = db.Book.ToList();

            var table = from a in books
                                join b in authors on a.author_id equals b.author_id
                                select new BooksViewModel()
                                {
                                    IdBook = a.id,
                                    Name = a.name,
                                    AuthorName = b.first_name + " " + b.last_name
                                };

            return View(table);
        }

       

        public IActionResult Create()
        {
            BooksViewModel model = new BooksViewModel();

            List<Authors> authorsList = new List<Authors>();

            authorsList = (from author in db.Author
                           select author).ToList();

            model.Authors = authorsList;

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(BooksViewModel model)
        {
            Books book = db.Book.FirstOrDefault();

            if (ModelState.IsValid)
            {
                book = new Books 
                { 
                    id = Guid.NewGuid(), 
                    name = model.Name, 
                    author_id = model.AuthorId 
                };

                db.Book.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Details(Guid? id)
        {
            if (id != null)
            {
                var authors = db.Author.ToList();
                var books = db.Book.ToList();

                var table = from a in books
                                join b in authors on a.author_id equals b.author_id
                                where a.id == id
                                select new BooksViewModel()
                                {
                                    IdBook = a.id,
                                    Name = a.name,
                                    AuthorName = b.first_name + " " + b.last_name
                                };
                if (table != null)
                        return View(table);
            }
            return NotFound();
        }

        public IActionResult Edit(Guid? id)
        {
            Books books = db.Book.FirstOrDefault(p => p.id == id);
            List<Authors> authorsList = new List<Authors>();

            authorsList = (from author in db.Author
                           select author).ToList();

            var model = new BooksViewModel()
            {
                IdBook = (Guid)id,
                Name = books.name,
                Authors = authorsList
            };

            return View(model);
        }
            
        [HttpPost]
        public IActionResult Edit(BooksViewModel model, Guid? id)
        {

            if (ModelState.IsValid)
            {
                Books book = db.Book.Where(x => x.id == id).FirstOrDefault();

                book.name = model.Name;
                book.author_id = model.AuthorId;

                db.Book.Update(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

        }

        [HttpGet]
        public IActionResult Delete(Guid? id)
        {
            if (id != null)
            {
                Books books = db.Book.FirstOrDefault(p => p.id == id);
                if (books != null)
                    db.Book.Remove(books);
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}

