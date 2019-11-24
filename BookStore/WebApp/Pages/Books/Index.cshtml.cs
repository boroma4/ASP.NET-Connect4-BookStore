using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;
using WebApp.DTO;

namespace WebApp.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<BookIndexDto> Books { get; set; }

        public IList<Book> Book { get; set; }


        public string? Search { get; set; }
        
        public string? Type { get; set; }

        public int Total { get; set; }
        
        

        public async Task OnGetAsync(string? search, string? toDoActionReset, string? type)
        {
            
            if (toDoActionReset == "Reset")
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

            var bookQuery = _context.Books
                .Include(b => b.Language)
                .Include(b => b.Publisher)
                .Include(b => b.BookAuthors)
                .ThenInclude(a => a.Author)
                //.Include(b => b.Comments)
                .Select(a => new BookIndexDto()
                {
                    Book = a, 
                    CommentCount = 0, // 
                    LastComment = "", //a.Comments.LastOrDefault().CommentText
                })
                .AsQueryable();

            Total = bookQuery.Count();

            if (!string.IsNullOrWhiteSpace(Search) && type != null)
            {
                switch (type)
                {
                    case "Title":
                        bookQuery = bookQuery
                            .Where(b =>
                                b.Book.Title.ToLower().Contains(Search));
                        break;
                    
                    case "Author":
                        bookQuery = bookQuery
                            .Where(b =>
                                b.Book.BookAuthors.Any(a =>
                                    a.Author.FirstName.ToLower().Contains(Search) ||
                                    a.Author.LastName.ToLower().Contains(Search))
                            );
                        break;
                    
                    case "Publisher":
                        bookQuery = bookQuery
                            .Where(b =>
                                b.Book.Publisher.PublisherName.ToLower().Contains(Search)
                            );

                        break;


                    default:
                        return;
                    
                }

                Type = type;

            }

            //bookQuery = bookQuery.Select(a => new BookIndexDto(){Book = a});

            bookQuery = bookQuery.OrderBy(b => b.Book.Title);
            
            Books = await bookQuery.ToListAsync();

            foreach (var book in Books)
            {
                book.CommentCount = await _context.Comments.Where(c => c.BookId == book.Book.BookId).CountAsync();
                book.LastComment = (
                    await _context.Comments
                        .Where(c => c.BookId == book.Book.BookId)
                        .OrderByDescending(c => c.CommentId).FirstOrDefaultAsync())?.CommentText;
            }
            
        }
    }
}
