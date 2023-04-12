using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Models
{
    public class BookCreateUpdateModel: BookModel
    {
        public List<Guid> AuthorsIds { get; set; } = new List<Guid>();
    }
}
