using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;

namespace WebApp.Pages_Comments
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public Book? BookToComment { get; set; }
        public int? BookId { get; set; }

        public IActionResult OnGet(int bookId)
        {
            BookId = bookId;
            try
            {
                BookToComment = _context.Books.Find(BookId);
            }
            catch (Exception e)
            {
                return NotFound();
            }

            return Page();
        }

        [BindProperty]
        public Comment Comment { get; set; } = new Comment();

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int bookId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Comment.BookId = bookId;

            _context.Comments.Add(Comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
