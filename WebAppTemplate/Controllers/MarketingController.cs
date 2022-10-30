using DAL.BOMContext;
using Microsoft.AspNetCore.Mvc;

namespace BusinessOverviewManagerClient.Controllers
{
    [Route("[controller]")]
    public class MarketingController : Controller
    {
        private bomContext db;
        public MarketingController(bomContext _db)
        {
            db = _db;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
