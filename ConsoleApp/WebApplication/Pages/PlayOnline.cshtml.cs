using System.Reflection.PortableExecutable;
using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages
{
    public class Start : PageModel
    {
        private readonly AppDbContext _context;

        public GameSettings Settings { get; set; } = default!;

        public Start(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Settings = _context.Settings.Find(0);
        }
    }
}