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

namespace WebApp.Pages_Books
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public int AuthorId { get; set; }

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["LanguageId"] = new SelectList(_context.Languages, "LanguageId", "LanguageName");
        ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherName");
        ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "FirstLastName");
        
        return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

//            var findAuthor = _context.Authors
//                .Include(b => b.YearOfBirth)
//                .Include(b => b.FirstName)
//                .Include(b => b.LastName)
//                .Include(b => b.AuthorBooks)
//                .Where(i => i.AuthorId == AuthorId).ToList();
//            
//            
//            Book.BookAuthors.Add(new BookAuthor()
//            {
//                Author = findAuthor[0],
//                AuthorId = findAuthor[0].AuthorId,
//                BookId = Book.BookId,
//                Book = this.Book
//            });
//            
            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
