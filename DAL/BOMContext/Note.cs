using System;
using System.Collections.Generic;

namespace DAL.BOMContext
{
    public partial class Note
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
