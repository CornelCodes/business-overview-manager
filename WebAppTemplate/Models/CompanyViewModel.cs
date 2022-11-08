using DAL.BOMContext;
using DAL.Models;

namespace BusinessOverviewManagerClient.Models
{
    public class CompanyViewModel
    {
        public Company Company { get; set; } = new Company();
        public string ContactNumber { get; set; } = "";
        public string AlternativeContactNumber { get; set; } = "";
        public string Address { get; set; } = "";
        public List<SocialMediaPlatform> SocialMediaPlatforms { get; set; } = new List<SocialMediaPlatform>();

    }
}
