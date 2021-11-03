using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class AuthorsModel
    {
        public Guid AuthorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
