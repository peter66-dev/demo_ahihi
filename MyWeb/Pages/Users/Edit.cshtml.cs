using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLib.DataAccess;
using MyLib.Models;
using MyLib.Repository;

namespace MyWeb.Pages.Users
{
    public class EditModel : PageModel
    {
        private IUserRepository userRepo;
        public EditModel()
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (userRepo.CheckNameDuplicated(AccountUser.UserId, AccountUser.UserFullName))
            {
                AccountUser = userRepo.GetUserById(AccountUser.UserId);
                ViewData["Message"] = "This name has existed in system!";
                return Page();
            }
            else
            {
                if (userRepo.UpdateUser(AccountUser))
                {
                    Console.WriteLine("Updated!");
                }
                else
                {
                    Console.WriteLine("Updating failed!");
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
