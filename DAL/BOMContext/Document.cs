using System;
using System.Collections.Generic;

namespace DAL.BOMContext
{
    public partial class Document
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Binary { get; set; } = null!;
        public string FileType { get; set; } = null!;

        public virtual Company Company { get; set; } = null!;
    }
}
