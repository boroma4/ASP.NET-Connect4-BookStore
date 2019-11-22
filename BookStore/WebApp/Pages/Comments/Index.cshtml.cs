using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages_Comments
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Comment> Comment { get;set; }

        public int? BookId { get; set; }

        public async Task OnGetAsync(int? bookId)
        {
            if(bookId == null){
                Comment = await _context.Comments
                .Include(c => c.Book).ToListAsync();
            }
            else
            {
                BookId = bookId;
                Comment = await _context.Comments
                    .Where(c => c.BookId == bookId)
                    .Include(c => c.Book).ToListAsync();
            }
        }
    }
}
