using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages_Languages
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public bool SameFound { get; set; }

        [BindProperty]
        public Language Language { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SameFound = _context.Languages
                .Any(l => (l.LanguageName.ToLower()) == (Language.LanguageName.ToLower()));

            if (!SameFound)
            {
                _context.Languages.Add(Language);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            
            return Page();
        }
    }
}
