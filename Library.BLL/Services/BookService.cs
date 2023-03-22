using System;
using Library.DAL;
using System.Linq;
using Library.DAL.Entities;
using System.Collections.Generic;


namespace Library.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationContext context;
        public BookService(ApplicationContext context)
        {
            this.context = context;
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
                return false;
            }
        }

        Book IBookService.GetById(Guid id)
        {
            return context.Books.Find(id);
        }

        public List<Book> GetAll(int offset, int limit)
        {
            return context.Books.Skip(offset).Take(limit).ToList();
        }
    }
}
