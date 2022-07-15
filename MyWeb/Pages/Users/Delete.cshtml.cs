using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyLib.DataAccess;
using MyLib.Models;
using MyLib.Repository;

namespace MyWeb.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private IUserRepository userRepo;

        public DeleteModel()
        {
            userRepo = new UserRepository();
        }

        [BindProperty]
        public AccountUser AccountUser { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string adminid = HttpContext.Session.GetString("ADMIN_ID");
            if (adminid == null)
            {
                return RedirectToPage("../Index");
            }

            AccountUser = userRepo.GetUserById(id);

            if (AccountUser == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string adminid = HttpContext.Session.GetString("ADMIN_ID");
            if (adminid == null)
            {
                return RedirectToPage("../Index");
            }


            if (AccountUser != null)
            {
                if (userRepo.DeleteUser(id))
                {
                    Console.WriteLine("Deleted!");
                }
                else
                {
                    AccountUser = userRepo.GetUserById(id);
                    Console.WriteLine("Deleting failed!");
                    return Page();
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
