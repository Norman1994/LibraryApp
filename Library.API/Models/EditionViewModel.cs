using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Models
{
    public class EditionViewModel
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public byte[] Cover { get; set; }

        public string IssueYear { get; set; }

        public string Publisher { get; set; }

        public string Code { get; set; }
    }
}
