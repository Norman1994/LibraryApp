using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DAL.Entities
{
    [Table("authors", Schema = "public")]
    public class Author
    {
        [Key]
        [Column("author_id")]
        public Guid Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [NotMapped]
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
