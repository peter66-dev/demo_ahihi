using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyLib.DataAccess;
using MyLib.Models;

namespace MyWeb.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly MyLib.DataAccess.BookPublisherContext _context;

        public IndexModel(MyLib.DataAccess.BookPublisherContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Books
                .Include(b => b.Publisher).ToListAsync();
        }
    }
}
