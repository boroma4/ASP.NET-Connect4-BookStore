using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml.Linq;
using DAL;
using Domain;
using GameEngine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Pages
{
    public class StartNew : PageModel
    {
        private readonly AppDbContext _context;
        
        public StartNew(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public GameSettings Settings { get; set; } = new GameSettings();

        private static readonly List<string> Types = new List<string>()
        {
            "Small","Medium","Large","Custom"
        };

        public SelectList Boards { get; set; } = new SelectList(Types);

        [BindProperty]
        public string SelectedBoardType { get; set; } = default!;

        public bool IsCustomBoard { get; set; } = default!;

        public bool VsBot { get; set; }
        
        [BindProperty]
        public bool BotIsFirst { get; set; }
        
        
        public void OnGet(bool bot)
        {
            VsBot = bot;
        }

        public IActionResult OnPostAsync(bool bot)
        {
            switch (SelectedBoardType)
            {
               case "Small":
                   Settings.BoardHeight = 4;
                   Settings.BoardWidth = 5;
                   break;
               case "Medium":
                   Settings.BoardHeight = 7;
                   Settings.BoardWidth = 8;
                   break;
               case "Large":
                   Settings.BoardHeight = 7;
                   Settings.BoardWidth = 10;
                   break;
               case "Custom":
                   if ((Settings.BoardWidth < 4 || Settings.BoardWidth > 10) && (Settings.BoardHeight < 4 || Settings.BoardHeight > 10))
                   {
                       VsBot = bot;
                       IsCustomBoard = true;
                       return Page();
                   }
                   break;
               default:
                   throw new InvalidOperationException("No such board size!");
            }

            Settings.IsPlayerOne = !BotIsFirst;
            Settings.VersusBot = bot;
            Settings.Board = new CellState[Settings.BoardHeight,Settings.BoardWidth];
            Settings.YCoordinate = new int[Settings.BoardWidth];
            Saver.SaveGame(Settings,true);
            return RedirectToPage("PlayOnline");
        }
    }
}