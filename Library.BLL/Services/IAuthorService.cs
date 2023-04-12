using System;
using Library.DAL.Entities;
using System.Collections.Generic;
using Library.BLL.Dto;

namespace Library.BLL.Services
{
    public interface IAuthorService
    {
        bool Create(AuthorDto authorDto);

        bool Update(AuthorDto authorDto);

        bool? Delete(Guid id);

        Author GetById(Guid id);

        List<Author> GetAuthors(int offset, int limit);
    }
}
