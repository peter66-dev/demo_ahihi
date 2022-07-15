using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyLib.DataAccess;
using MyLib.Models;
using MyLib.Repository;

namespace MyWeb.Pages.Users
{
    public class CreateModel : PageModel
    {
        private IUserRepository userRepo;

        public CreateModel()
        {
            userRepo = new UserRepository();
        }

        public IActionResult OnGet()
        {
            string adminid = HttpContext.Session.GetString("ADMIN_ID");
            if (adminid == null)
            {
                return RedirectToPage("../Index");
            }
            return Page();
        }

        [BindProperty]
        public AccountUser AccountUser { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string adminid = HttpContext.Session.GetString("ADMIN_ID");
            if (adminid == null)
            {
                return RedirectToPage("../Index");
            }

            if (userRepo.CreateUser(AccountUser))
            {
                Console.WriteLine("Created!");
            }
            else
            {
                Console.WriteLine("Creating failed!");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
