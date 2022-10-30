using DAL.BOMContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace BusinessOverviewManagerClient.Controllers
{
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private bomContext mDb;
        public CompanyController(bomContext _db)
        {
            mDb = _db;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var userId = DAL.Helpers.AuthenticationHelper.GetUserId(HttpContext);
            var user = await mDb.Users.Include(x => x.Companies.OrderBy(y => y.Id)).FirstOrDefaultAsync(x => x.Id == Int64.Parse(userId));

            return View(user);
        }

        [HttpGet("[action]/{companyId}")]
        public async Task<IActionResult> Details(long companyId)
        {
            var company = await mDb.Companies.FirstOrDefaultAsync(x => x.Id == companyId);
            if (company == null)
            {
                company = new Company();
            }
            return View(company);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(Company vm)
        {
            try
            {
                var userId = Int64.Parse(DAL.Helpers.AuthenticationHelper.GetUserId(HttpContext));
                var company = await mDb.Companies.FirstOrDefaultAsync(x => x.Id == vm.Id);

                if (company != null)
                {
                    //update properties
                    company.Name = vm.Name;
                }
                else
                {
                    //create new
                    company = new Company()
                    {
                        Name = vm.Name,
                        UserId = userId
                    };
                    await mDb.Companies.AddAsync(company);
                }

                await mDb.SaveChangesAsync();
                vm = company;
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
