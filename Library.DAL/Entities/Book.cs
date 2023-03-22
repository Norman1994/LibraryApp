using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DAL.Entities
{
    [Table("books", Schema = "public")]
    public class Book
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("author_id")]
        public Guid AuthorId { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("cover")]
        public byte[] Cover { get; set; }

        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
