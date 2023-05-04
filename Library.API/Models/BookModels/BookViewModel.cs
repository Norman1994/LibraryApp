using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library.API.Models
{
    public class BookViewModel: BookModel
    {
        public string AuthorName { get; set; }

        public Guid AuthorId { get; set; }

        public List<EditionViewModel> Editions { get; set; }
    }
}
