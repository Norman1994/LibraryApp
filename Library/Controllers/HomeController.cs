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
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Create(Books books)
            {
                books.id = Guid.NewGuid();
                db.Book.Add(books);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
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

            public async Task<IActionResult> Edit(Guid? id)
            {
                if (id != null)
                {
                /*Books books = await db.Book.FirstOrDefaultAsync(p => p.id == id);
                if (books != null)
                    return View(books);*/

                var authors = db.Author.ToList();
                var books = db.Book.ToList();
                /*var table = from a in authors
                            join b in books on a.author_id equals b.author_id
                            where b.id == id
                            select a;*/

                BooksViewModel view = new BooksViewModel();
                if (authors != null)
                {
                    ViewBag.data = new SelectList(authors, "author_id", "first_name", view.Authors.author_id);
                }


                /*var table = from a in books
                            join b in authors on a.author_id equals b.author_id
                            where a.id == id
                            select new BooksViewModel()
                            {
                                IdBook = a.id,
                                Name = a.name,
                                AuthorId = b.author_id,
                                AuthorName = b.first_name + " " + b.last_name
                            };*/
                    Books book = await db.Book.FirstOrDefaultAsync(p => p.id == id);
                    if (books != null)
                        return View(book);
                }

        
                return NotFound();
            }
            [HttpPost]
            public IActionResult Edit(Books book)
            {
                db.Book.Update(book);
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            [HttpGet]
            [ActionName("Delete")]
            public async Task<IActionResult> ConfirmDelete(Guid? id)
            {
                if (id != null)
                {
                    Books books = await db.Book.FirstOrDefaultAsync(p => p.id == id);
                    if (books != null)
                        return View(books);
                }
                return NotFound();
            }

            [HttpPost]
            public async Task<IActionResult> Delete(Guid? id)
            {
                if (id != null)
                {
                    Books books = await db.Book.FirstOrDefaultAsync(p => p.id == id);
                    if (books != null)
                        db.Book.Remove(books);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                }
                return NotFound();
            }
        }
    }

