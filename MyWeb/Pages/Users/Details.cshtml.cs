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

namespace MyWeb.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly MyLib.DataAccess.BookPublisherContext _context;

        public DetailsModel(MyLib.DataAccess.BookPublisherContext context)
        {
            _context = context;
        }

        public AccountUser AccountUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
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

            AccountUser = await _context.AccountUsers.FirstOrDefaultAsync(m => m.UserId == id);

            if (AccountUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
