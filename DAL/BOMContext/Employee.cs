using System;
using System.Collections.Generic;

namespace DAL.BOMContext
{
    public partial class Employee
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public long CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
    }
}
