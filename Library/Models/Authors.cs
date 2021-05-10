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
        public Guid author_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

        public List<Books> Books { get; set; } = new List<Books>();
    }
}
