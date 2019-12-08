using System;
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
        public List<(string name,string time)> Games { get; set; } = new List<(string name,string time)>();


        public bool RuntimeSave { get; set; }
        
        public  void OnGet(bool save)
        {
            for (var i = 0; i < AvailableSaves.MAXSAVES; i++)
            {
                var res = _context.Settings.Find(i) ?? new GameSettings();
                Games.Add(res.WebStrings());
            }
            RuntimeData.GamesExternal = Games;
           
            RuntimeSave = save;
        }

        public IActionResult OnPost(int id)
        {
            return RedirectToPage("./PlayOnline",new {id});
        }
        public IActionResult OnPostSave(int id)
        {
            var settings = RuntimeData.GameSettings;
            Saver.SaveGame(settings,false,id,true);
            return RedirectToPage("./PlayOnline",new {id});
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var GameToDelete =  _context.Settings.Find(id);
            _context.Settings.Remove(GameToDelete);
            await _context.SaveChangesAsync();
            RuntimeData.GamesExternal[id] = ("Empty", "N/A");
            Games = RuntimeData.GamesExternal;
            return Page();
        }
    } 
}
