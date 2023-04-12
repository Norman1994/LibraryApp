using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BLL.Dto
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
