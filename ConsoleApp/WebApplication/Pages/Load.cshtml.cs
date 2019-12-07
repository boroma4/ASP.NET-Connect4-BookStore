using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Domain;
using GameEngine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace WebApplication.Pages
{
    public class Load : PageModel
    {
        private readonly AppDbContext _context;

        public Load(AppDbContext context)
        {
            _context = context;
        }

        public List<(string,string)> Games { get; } = new List<(string,string)>();

        public  void OnGet()
        {
            for (var i = 0; i < AvailableSaves.MAXSAVES; i++)
            {
                var res = _context.Settings.Find(i) ?? new GameSettings();
                Games.Add(res.WebStrings());
            }
        }

        public IActionResult OnPost(int id)
        {
            id -= 1;
            return RedirectToPage("./PlayOnline",new {id});
        }
    }
}