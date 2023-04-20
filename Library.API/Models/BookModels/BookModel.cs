using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Models
{
    public class BookModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Rating { get; set; }

        public string IssueYear { get; set; }

        public string Annotation { get; set; }

        public int PageCount { get; set; }

        public string Description { get; set; }

        public byte[] Cover { get; set; }

        public List<Edition> Editions = new List<Edition>();
    }
}
