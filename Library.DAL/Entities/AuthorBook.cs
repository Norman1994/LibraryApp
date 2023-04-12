using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.DAL.Entities
{
    public class AuthorBook
    {
        public Guid AuthorsId { get; set; }

        public Guid BooksId { get; set; }

        public Author Author { get; set; }

        public Book Book { get; set; }
    }
}
