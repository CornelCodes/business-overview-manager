using DAL.BOMContext;
using Microsoft.AspNetCore.Mvc;

namespace BusinessOverviewManagerClient.Controllers
{
    [Route("[controller]")]
    public class FileController : Controller
    {
        private bomContext mDb;
        public FileController(bomContext db)
        {
            mDb = db;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            //show all files for user or company
            return View();
        }
    }
}
