using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages_Books
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }
        public string? Search { get; set; }

        public async Task OnGetAsync(string? search, string? action)
        {
            if (action == "Reset")
            {
                Search = "";
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(search))
                {
                    Search = search.ToLower().Trim();
                }
            }

            search = Search;
            if (string.IsNullOrEmpty(search))
            {
                Book = await _context.Books
                    .Include(b => b.Language)
                    .Include(b => b.Publisher)
                    .Include(b=>b.Comments)
                    .Include(b=>b.BookAuthors)
                    .ThenInclude(b=> b.Author)
                    .OrderBy(b=>b.Title)
                    .ToListAsync();
            }
            else
            {
                search = search.ToLower().Trim();
                Book = await _context.Books
                    .Include(b => b.Language)
                    .Include(b => b.Publisher)
                    .Include(b=>b.Comments)
                    
                    .Include(b=>b.BookAuthors)
                    .ThenInclude(b=> b.Author)
                    .Where(b=> 
                        b.Title.ToLower().Contains(search)||
                        b.Publisher.PublisherName.ToLower().Contains(search)||
                        b.BookAuthors.Any(a =>a.Author.FirstName.ToLower().Contains(search)||
                                              a.Author.LastName.ToLower().Contains(search)))
                    
                    .OrderBy(b=>b.Title)
                    .ToListAsync();
            }

        }
    }
}
