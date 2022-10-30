using DAL.BOMContext;
using Microsoft.AspNetCore.Mvc;

namespace BusinessOverviewManagerClient.Controllers
{
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private bomContext db;
        public CompanyController(bomContext _db)
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
