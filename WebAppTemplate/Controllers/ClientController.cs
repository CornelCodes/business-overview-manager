using DAL.BOMContext;
using Microsoft.AspNetCore.Mvc;

namespace BusinessOverviewManagerClient.Controllers
{
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private bomContext db;
        public ClientController(bomContext _db)
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
