using Library.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public List<Authors> Authors { get; set; }
    }
}
