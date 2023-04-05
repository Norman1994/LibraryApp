using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Models
{
    public class BookAuthorModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string AuthorName { get; set; }

        public int Rating { get; set; }

        public string IssueYear { get; set; }

        public string Annotation { get; set; }

        public int PageCount { get; set; }

        public string Description { get; set; }

        public byte[] Cover { get; set; }
    }
}
