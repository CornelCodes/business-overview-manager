using System;
using System.Collections.Generic;

namespace DAL.BOMContext
{
    public partial class User
    {
        public User()
        {
            Companies = new HashSet<Company>();
            Notes = new HashSet<Note>();
        }

        public long Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
