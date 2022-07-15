using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLib.DataAccess;
using MyLib.Models;
using MyLib.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWeb.Pages.Users
{
    public class IndexModel : PageModel
    {
        private IUserRepository userRepo;

        public IndexModel(BookPublisherContext context)
        {
            userRepo = new UserRepository();
        }

        public IEnumerable<AccountUser> AccountUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string searchString)
        {
            string adminid = HttpContext.Session.GetString("ADMIN_ID");
            if (adminid == null)
            {
                return RedirectToPage("../Index");
            }
            if (searchString == null)
            {
                AccountUser = await userRepo.GetAllUsersAsync();
            }
            else
            {
                AccountUser = await userRepo.Search(searchString);
            }

            return Page();
        }


    }
}
