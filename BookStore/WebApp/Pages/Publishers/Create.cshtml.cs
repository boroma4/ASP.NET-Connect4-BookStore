using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;

namespace WebApp.Pages_Publishers
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }
        
        public bool SameFound { get; set; }


        public string? Action { get; set; }
        public IActionResult OnGet(string? action)
        {
            Action = action;
            return Page();
        }

        [BindProperty]
        public Publisher Publisher { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string? action)
        {
            SameFound = _context.Publishers
                .Any(p => (p.PublisherName.ToLower()) == (Publisher.PublisherName.ToLower()));
            
            if (!ModelState.IsValid || SameFound)
            {
                return Page();
            }
            

            _context.Publishers.Add(Publisher);
            await _context.SaveChangesAsync();
            
            if (action == "CreateAndGoBack")
            {
                return RedirectToPage("/Books/Create");
            }

            return RedirectToPage("./Index");
        }
    }
}
