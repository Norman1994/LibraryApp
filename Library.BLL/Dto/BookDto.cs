using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BLL.Dto
{
    public class BookDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Rating { get; set; }

        public string IssueYear { get; set; }

        public string Annotation { get; set; }

        public int PageCount { get; set; }

        public string Description { get; set; }

        public byte[] Cover { get; set; }

        public List<Guid> AuthorsIds { get; set; } = new List<Guid>();
    }
}
