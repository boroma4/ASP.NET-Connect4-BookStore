using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;

namespace WebApp.Pages_Authors
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public string? Action { get; set; }

        public IActionResult OnGet(string? action)
        {
            Action = action;
            return Page();
        }

        public bool SameFound { get; set; }
        
        public bool InvalidYear { get; set; }

        public string ErrorMessage { get; set; } = default!;

        [BindProperty] public Author Author { get; set; } = default!;

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string? action)
        {
            SameFound = _context.Authors
                .Any(a => (a.FirstName.ToLower()) == (Author.FirstName.ToLower())
                          && (a.LastName.ToLower()) == (Author.LastName.ToLower()));
            InvalidYear = Author.YearOfBirth > DateTime.Now.Year;

            if (InvalidYear)
            {
                ErrorMessage += "We haven't reached that year yet.";
            }

            if (SameFound)
            {
                ErrorMessage += "\nAuthor with the same name is already on the list, maybe try editing.";
            }
            
            if (!ModelState.IsValid || SameFound || InvalidYear)
            {
                return Page();
            }

            _context.Authors.Add(Author);
            await _context.SaveChangesAsync();

            if (action == "CreateAndGoBack")
            {
                return RedirectToPage("/Books/Create");
            }

            return RedirectToPage("./Index");
        }
    }
}
