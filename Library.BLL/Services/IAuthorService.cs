using System;
using Library.DAL.Entities;
using System.Collections.Generic;

namespace Library.BLL.Services
{
    public interface IAuthorService
    {
        bool Create(Author author);

        bool Update(Author author);

        bool? Delete(Guid id);

        Author GetById(Guid id);

        List<Author> GetAuthors(int offset, int limit);
    }
}
