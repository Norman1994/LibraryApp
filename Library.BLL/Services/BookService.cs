using System;
using Library.DAL;
using System.Linq;
using Library.DAL.Entities;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Library.BLL.Dto;
using AutoMapper;

namespace Library.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationContext context;
        private readonly ILogger<BookService> logger;
        private readonly IMapper mapper;
        public BookService(ApplicationContext context, ILogger<BookService> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }
        public bool Create(BookDto bookDto)
        {
            try
            {
                using (context)
                {
                    List<Author> authors = new List<Author>();
                    bookDto.AuthorsIds.ForEach((x) => { authors.Add(context.Authors.Find(x)); });

                    Book newBook = mapper.Map<Book>(bookDto);
                    newBook.Authors = authors;

                    context.Books.Add(newBook);
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

        public bool Update(BookDto bookDto)
        {
            try
            {

                //context.Books.Update(book);
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
            return context.Books.Include(x => x.Authors).Include(x => x.Editions).FirstOrDefault(x => x.Id == id);
        }

        public List<Book> GetAll(int offset, int limit)
        {
            //return context.Books.Include(x => x.Authors).Include(x => x.Editions).Skip(offset).Take(limit).ToList();
            return context.Books.Skip(offset).Take(limit).ToList();
        }
    }
}