using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DAL.Entities
{
    [Table("book", Schema = "public")]
    public class Book
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("cover")]
        public byte[] Cover { get; set; }

        [Column("issue_year")]
        public string IssueYear { get; set; }

        [Column("page_count")]
        public int PageCount { get; set; }

        [Column("rating")]
        public int Rating { get; set; }

        [Column("annotation")]
        public string Annotation { get; set; }

        [NotMapped]
        public virtual List<Author> Authors { get; set; } = new List<Author>();
        [NotMapped]
        public virtual List<Edition> Editions { get; set; } = new List<Edition>();
    }
}
