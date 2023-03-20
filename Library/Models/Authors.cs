using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("authors", Schema = "public")]
    public class Authors
    {
        [Key]
        [Column("author_id")]
        public Guid AuthorId { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }

        public List<Books> Books { get; set; } = new List<Books>();
    }
}
