using System;
using System.Collections.Generic;

namespace DAL.BOMContext
{
    public partial class Company
    {
        public Company()
        {
            Clients = new HashSet<Client>();
            Employees = new HashSet<Employee>();
            MarketingCampaigns = new HashSet<MarketingCampaign>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<MarketingCampaign> MarketingCampaigns { get; set; }
    }
}
