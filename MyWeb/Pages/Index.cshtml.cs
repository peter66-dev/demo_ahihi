using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyLib.Models;
using MyLib.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public UserLogin UserLogin { get; set; }
        private IUserRepository userRepo;

        public IndexModel()
        {
            userRepo = new UserRepository();
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            AccountUser user = userRepo.CheckLogin(UserLogin.UserId, UserLogin.Password);
            if (user != null)
            {
                if (user.UserRole == 1)
                {
                    HttpContext.Session.SetString("ADMIN_ID", user.UserId);
                    return RedirectToPage("./Users/Index");
                }
                else if (user.UserRole == 2 || user.UserRole == 3)
                {
                    ViewData["LoginMessage"] = "Chào mừng bạn đến với chúng tôi!";
                }
            }
            else
            {
                ViewData["LoginMessage"] = "Sai tài khoản mật khẩu!";
            }
            return Page();
        }
    }
}
