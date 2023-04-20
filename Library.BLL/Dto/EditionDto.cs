using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BLL.Dto
{
    public class EditionDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public byte[] Cover { get; set; }

        public string IssueYear { get; set; }

        public string Publisher { get; set; }
    }
}
