using DAL.BOMContext;
using Microsoft.AspNetCore.Mvc;

namespace BusinessOverviewManagerClient.Controllers
{
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private bomContext db;
        public EmployeeController(bomContext _db)
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
