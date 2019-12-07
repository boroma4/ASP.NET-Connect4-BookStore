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

        public List<(string name,string time)> Games { get; } = new List<(string name,string time)>();

        public bool RuntimeSave { get; set; }

        public  void OnGet(bool save)
        {
            for (var i = 0; i < AvailableSaves.MAXSAVES; i++)
            {
                var res = _context.Settings.Find(i) ?? new GameSettings();
                Games.Add(res.WebStrings());
            }

            RuntimeSave = save;
        }

        public IActionResult OnPost(int id)
        {
            id -= 1;
            return RedirectToPage("./PlayOnline",new {id});
        }
        public IActionResult OnPostSave(int id)
        {
            var settings = Helper.GameSettings;
            var name = settings.FirstPlayerName + "-" + settings.SecondPlayerName;
            settings.SaveName = name;
            settings.SaveTime = DateTime.Now.ToString("MM/dd/yyyy H:mm:ss");
            GameConfigHandler.SaveConfig(settings, id);
            return RedirectToPage("./PlayOnline",new {id});
        }
    }
}