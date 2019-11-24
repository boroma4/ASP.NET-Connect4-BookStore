using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        
        
       // Ideally must be generated for every client based on IP or something
        private readonly int UserId = 33;


        [BindProperty] public int AuthorId { get; set; }

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public Book Book { get; set; } = new Book();
        

        public SelectList AuthorsSelectList { get; set; }



        [BindProperty] public ICollection<int> BookAuthorIds { get; set; }

        public IActionResult OnGet()
        {
            ViewData["LanguageId"] = new SelectList(_context.Languages, "LanguageId", "LanguageName");
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherName");
            AuthorsSelectList = new SelectList(_context.Authors, "AuthorId", "FirstLastName");
            
            var savedData = _context.UnfinishedForms.Find(UserId);
            if (savedData != null)
            {
                Book.Title = savedData.Title;
                Book.Summary = savedData.Summary;
                Book.AuthoredYear = savedData.AuthoredYear ?? 0;
                Book.PublishingYear = savedData.PublishingYear ?? 0;
                Book.LanguageId = savedData.Language ?? 0;
                Book.PublisherId = savedData.Publisher ?? 0;
            }

            return Page();
        }




        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.
            public async Task<IActionResult> OnPostAsync()
            {

                if (!ModelState.IsValid)
                {
                    ViewData["LanguageId"] = new SelectList(_context.Languages, "LanguageId", "LanguageName");
                    ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherName");
                    AuthorsSelectList = new SelectList(_context.Authors, "AuthorId", "FirstLastName");
                    return Page();
                }

                _context.Books.Add(Book);
                _context.SaveChanges();

                foreach (var bookAuthorId in BookAuthorIds)
                {
                    _context.BookAuthors.Add(new BookAuthor()
                    {
                        BookId = _context.Books.Find(this.Book.BookId).BookId,
                        AuthorId = bookAuthorId
                    });
                }

                
                if (_context.UnfinishedForms.Find(UserId) != null)
                {
                    _context.UnfinishedForms.Remove(_context.UnfinishedForms.Find(UserId));
                }
                await _context.SaveChangesAsync();
               
                return RedirectToPage("./Index");
            }

        public async Task<IActionResult> OnPostRedirectAsync()
        {
            Console.WriteLine("ModelState is "+ ModelState.IsValid );

            if (_context.UnfinishedForms.Find(UserId) != null)
            {
                _context.UnfinishedForms.Remove(_context.UnfinishedForms.Find(UserId));
                _context.SaveChanges();
            }
            
            _context.UnfinishedForms.Add(new UnfinishedForm()
            {
                UnfinishedFormId = 33,
                Title = Book.Title,
                Summary = Book.Summary,
                AuthoredYear = Book.AuthoredYear,
                Language = Book.LanguageId,
                Publisher = Book.PublisherId
            });

            await _context.SaveChangesAsync();

            return RedirectToPage("/Authors/Create",new {action = "CreateAndGoBack"});
       }
        
    }
}
