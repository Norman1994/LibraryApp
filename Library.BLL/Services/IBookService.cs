using System;
using Library.DAL.Entities;
using System.Collections.Generic;
using Library.BLL.Dto;

namespace Library.BLL.Services
{
    public interface IBookService
    {
        bool Create(BookDto book);

        bool Update(Book book);

        bool? Delete(Guid id);

        Book GetById(Guid id);

        List<Book> GetAll(int offset, int limit);
    }
}
