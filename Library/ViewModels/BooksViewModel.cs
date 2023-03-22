using Library.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class BookViewModel
    {
        public Guid IdBook { get; set; }
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }

        public string Description { get; set; }

        public List<Author> Authors { get; set; }
    }
}
