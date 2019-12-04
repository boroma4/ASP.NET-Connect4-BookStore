using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Pages
{
    public class Load : PageModel
    {
        private readonly AppDbContext _context;

        public Load(AppDbContext context)
        {
            _context = context;
        }

        public IList<GameSettings> Games { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Games =  await _context.Settings
                .ToListAsync();
        }
    }
}