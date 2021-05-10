using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("books", Schema = "public")]
    public class Books
    {
        [Key]    
        public Guid id { get; set; }
        public string name { get; set; }
        public Guid author_id { get; set; }

        public List<Authors> Authors { get; set; } = new List<Authors>();
    }
}
