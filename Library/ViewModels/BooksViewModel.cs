using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class BooksViewModel
    {
        public Guid IdBook { get; set; }
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }

        public Authors Authors { get; set; }
    }
}
