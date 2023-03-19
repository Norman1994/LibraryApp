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
        public Guid Author_id { get; set; }
        [Column("first_name")]
        public string First_name { get; set; }
        [Column("last_name")]
        public string Last_name { get; set; }

        public List<Books> Books { get; set; } = new List<Books>();
    }
}
