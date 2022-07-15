using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyLib.DataAccess;
using MyLib.Models;

namespace MyWeb.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly MyLib.DataAccess.BookPublisherContext _context;

        public CreateModel(MyLib.DataAccess.BookPublisherContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherId");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
