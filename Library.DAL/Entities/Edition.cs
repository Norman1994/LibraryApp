using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library.DAL.Entities
{
    [Table("edition", Schema = "public")]
    public class Edition
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("book_id")]
        public Guid BookId { get; set; }

        [Column("cover")]
        public byte[] Cover { get; set; }

        [Column("issue_year")]
        public string IssueYear { get; set; }

    }
}
