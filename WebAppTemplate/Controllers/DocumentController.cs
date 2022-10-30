using DAL.BOMContext;
using Microsoft.AspNetCore.Mvc;

namespace BusinessOverviewManagerClient.Controllers
{
    [Route("[controller]")]
    public class DocumentController : Controller
    {
        private bomContext db;
        public DocumentController(bomContext _db)
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
