using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.DAL;
using Library.DAL.Entities;
using Library.BLL.Services;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext db;
        private readonly IBookService bookService;

        public HomeController(ApplicationContext context, IBookService bookService)
        {
            db = context;
            this.bookService = bookService;
        }
        public IActionResult Index()
        {
            var authors = db.Authors.ToList();
            var books = db.Books.ToList();

            var table = from a in books
                                join b in authors on a.AuthorId equals b.Id
                                select new BookViewModel()
                                {
                                    IdBook = a.Id,
                                    Name = a.Name,
                                    AuthorName = b.FirstName + " " + b.LastName
                                };

            return View(table);
        }

       

        public IActionResult Create()
        {
            BookViewModel model = new BookViewModel();

            List<Author> authorsList = new List<Author>();

            authorsList = (from author in db.Authors
                           select author).ToList();

            model.Authors = authorsList;

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(BookViewModel model)
        {
            Book book = db.Books.FirstOrDefault();

            if (ModelState.IsValid)
            {
                book = new Book
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    AuthorId = model.AuthorId,
                    Description = model.Description
                };

                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Details(Guid? id)
        {
            if (id != null)
            {
                var authors = db.Authors.ToList();
                var books = db.Books.ToList();

                var table = from a in books
                                join b in authors on a.AuthorId equals b.Id
                                where a.Id == id
                                select new BookViewModel()
                                {
                                    IdBook = a.Id,
                                    Name = a.Name,
                                    AuthorName = b.FirstName + " " + b.LastName,
                                    Description = a.Description
                                };
                if (table != null)
                        return View(table);
            }
            return NotFound();
        }

        public IActionResult Edit(Guid? id)
        {
            Book books = db.Books.FirstOrDefault(p => p.Id == id);
            List<Author> authorsList = new List<Author>();

            authorsList = (from author in db.Authors
                           select author).ToList();

            var model = new BookViewModel()
            {
                IdBook = (Guid)id,
                Name = books.Name,
                Authors = authorsList,
                Description = books.Description
            };

            return View(model);
        }
            
        [HttpPost]
        public IActionResult Edit(BookViewModel model, Guid? id)
        {

            if (ModelState.IsValid)
            {
                Book book = db.Books.Where(x => x.Id == id).FirstOrDefault();

                book.Name = model.Name;
                book.AuthorId = model.AuthorId;
                book.Description = model.Description;

                db.Books.Update(book);
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
                Book books = db.Books.FirstOrDefault(p => p.Id == id);
                if (books != null)
                    db.Books.Remove(books);
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}

