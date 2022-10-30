using System;
using System.Collections.Generic;

namespace DAL.BOMContext
{
    public partial class MarketingCampaign
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public long CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
    }
}
