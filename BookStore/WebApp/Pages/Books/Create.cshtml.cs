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
        
        
        [BindProperty]
        public int AuthorId { get; set; }

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public int NumAuthors { get; set; }

        public SelectList AuthorsSelectList { get; set; }

        public IActionResult OnGet()
        {
        ViewData["LanguageId"] = new SelectList(_context.Languages, "LanguageId", "LanguageName");
        ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherName");
        AuthorsSelectList = new SelectList(_context.Authors, "AuthorId", "FirstLastName");
        return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        public IList<BookAuthor> BookAuthors { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _context.Books.Add(Book);
            
            _context.SaveChanges();
            
            _context.BookAuthors.Add(new BookAuthor()
            {
                BookId = _context.Books.Find(this.Book.BookId).BookId,
                AuthorId = AuthorId
                
            });
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


    }
}
