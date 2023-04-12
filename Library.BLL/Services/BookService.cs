using System;
using Library.DAL;
using System.Linq;
using Library.DAL.Entities;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Library.BLL.Dto;

namespace Library.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationContext context;
        private readonly ILogger<BookService> logger;
        public BookService(ApplicationContext context, ILogger<BookService> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public bool Create(BookDto bookDto)
        {
            try
            {
                using (context)
                {
                    List<Author> authors = new List<Author>();
                    bookDto.AuthorsIds.ForEach((x) => { authors.Add(context.Authors.Find(x)); });

                    //Author author = book.Authors.FirstOrDefault();
                    //book.Authors.Clear();
                    context.Books.Add(new Book
                    { 
                        Name = bookDto.Name,
                        Annotation = bookDto.Annotation,
                        Description = bookDto.Description,
                        IssueYear = bookDto.IssueYear,
                        PageCount = bookDto.PageCount,
                        Rating = bookDto.Rating,
                        Authors = authors
                    });
                    context.SaveChanges();

                }
                return true;
            }
            catch(Exception e)
            {
                logger.LogError(e.ToString());
                return false;
            }
            
        }

        public bool Update(Book book)
        {
            try
            {
                context.Books.Update(book);
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                return false;
            }
        }

        public bool? Delete(Guid id)
        {
            try
            {
                using (context)
                {
                    Book book = context.Books.Find(id);
                    if(book is null)
                    {
                        return null;
                    }
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
                return true;
            }
            catch(Exception e)
            {
                logger.LogError(e.ToString());
                return false;
            }
        }

        Book IBookService.GetById(Guid id)
        {
            return context.Books.Include(x => x.Authors).FirstOrDefault(x => x.Id == id);
        }

        public List<Book> GetAll(int offset, int limit)
        {
            return context.Books.Include(x => x.Authors).Skip(offset).Take(limit).ToList();
        }
    }
}