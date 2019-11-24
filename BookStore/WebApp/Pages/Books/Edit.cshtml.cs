using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages_Books
{
    public class EditModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public EditModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        [BindProperty]
        public ICollection<int>? BookAuthorIds { get; set; }

        public SelectList AuthorsSelectList { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books
                .Include(b => b.Language)
                .Include(b=>b.BookAuthors)
                .ThenInclude(a=> a.Author)
                .Include(b => b.Publisher).FirstOrDefaultAsync(m => m.BookId == id);

            if (Book == null)
            {
                return NotFound();
            }
            ViewData["LanguageId"] = new SelectList(_context.Languages, "LanguageId", "LanguageName");
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherName");
            AuthorsSelectList = new SelectList(_context.Authors, nameof(Author.AuthorId), nameof(Author.FirstLastName));
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (BookAuthorIds.Count != 0)
            {
                _context.BookAuthors.RemoveRange(_context.BookAuthors.Where(b => b.BookId == Book.BookId));
                _context.SaveChanges();

                foreach (var bookAuthorId in BookAuthorIds)
                {
                    _context.BookAuthors.Add(new BookAuthor()
                    {
                        BookId = Book.BookId,
                        AuthorId = bookAuthorId
                    });
                }
            }

            // a real hack i am sorry :(
            try
            {
                _context.Books.Update(Book);
            }
            catch (InvalidOperationException )
            {
                return NotFound();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.BookId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}
