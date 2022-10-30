using DAL.BOMContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessOverviewManagerClient.Controllers
{
    [Route("[controller]")]
    public class IdeaboardController : Controller
    {
        private bomContext mDb;
        public IdeaboardController(bomContext _db)
        {
            mDb = _db;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var userId = Int64.Parse(DAL.Helpers.AuthenticationHelper.GetUserId(HttpContext));
            var user = await mDb.Users.Include(x => x.Notes.OrderByDescending(x => x.Id)).FirstOrDefaultAsync(x => x.Id == userId);
            return View(user);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(Note vm)
        {
            try
            {
                var userId = Int64.Parse(DAL.Helpers.AuthenticationHelper.GetUserId(HttpContext));
                var note = await mDb.Notes.FirstOrDefaultAsync(x => x.Id == vm.Id);

                if (note != null)
                {
                    //update properties
                    note.Title = vm.Title;
                    note.Description = vm.Description;
                }
                else
                {
                    //create new
                    note = new Note()
                    {
                        Title = vm.Title,
                        Description = string.IsNullOrWhiteSpace(vm.Description) ? "" : vm.Description,
                        UserId = userId
                    };
                    await mDb.Notes.AddAsync(note);
                }

                await mDb.SaveChangesAsync();
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
