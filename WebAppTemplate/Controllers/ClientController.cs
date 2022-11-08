using DAL.BOMContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessOverviewManagerClient.Controllers
{
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private bomContext mDb;
        public ClientController(bomContext _db)
        {
            mDb = _db;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var userId = Int64.Parse(DAL.Helpers.AuthenticationHelper.GetUserId(HttpContext));
            var companies = await mDb.Companies.Where(x => x.UserId == userId).Include(x => x.Clients).ToListAsync();

            var testClients = new List<Client>()
            {
                new Client()
                {
                    FirstName = "Ben",
                    LastName = "Bob",
                    Id = 0,
                },
                new Client()
                {
                    FirstName = "Joe",
                    LastName = "Wilkinson",
                    Id = 1,
                },
                new Client()
                {
                    FirstName = "Sammy",
                    LastName = "Nick",
                    Id = 2,
                },
            };

            foreach (var company in companies)
            {
                company.Clients = testClients;
            }

            return View(companies);
        }
    }
}
