using System;
using Library.DAL;
using System.Linq;
using Library.DAL.Entities;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

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
        public bool Create(Book book)
        {
            try
            {
                using (context)
                {
                    context.Books.Add(book);
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
            Book book = context.Books.Include(x => x.Authors).FirstOrDefault(x => x.Id == id);
            return book;
        }

        public List<Book> GetAll(int offset, int limit)
        {
            return context.Books.Include(x => x.Authors).Skip(offset).Take(limit).ToList();
        }
    }
}