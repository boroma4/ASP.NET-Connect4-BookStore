using DAL;
using Domain;
using GameEngine;
using GamePlay;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages
{
    public class Start : PageModel
    {
        private readonly AppDbContext _context;

        public GameSettings Settings { get; private set; } = default!;

        public bool GameOver { get; private set; } = false;

        public bool FullBoard { get; private set; }

        public Start(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet(int? id)
        {
            Settings = id != null ? GameConfigHandler.LoadConfig(id.Value) : GameConfigHandler.LoadConfig();
            if (id == null)
            {
                for (var i = 0; i < Settings.BoardWidth; i++)
                {
                    Settings.YCoordinate[i] = Settings.BoardHeight - 1;
                }
            }

            if (!Settings.IsPlayerOne)
            {
                MakeATurn(Bot.MakeMove(Settings));
            }
            RuntimeData.GameSettings = Settings;
        }

        public IActionResult OnPost(int? userXint)
        {
            Settings = RuntimeData.GameSettings;

            if (userXint != null)
            {
                if (MakeATurn(userXint.Value) == "reload")
                {
                    return Page();
                }
                
                if (Settings.VersusBot && !Settings.IsPlayerOne)
                {
                    MakeATurn(Bot.MakeMove(Settings));
                }
            }

            if (!GameOver && !FullBoard)
            {
                Settings = RuntimeData.GameSettings;
                Saver.SaveGame(Settings,true);
            }
            //Really strange hack
            Settings = RuntimeData.GameSettings;
            
            return Page();
        }

        private string MakeATurn( int userXint)
        {
          
            //1. IF reached the top
            if (Settings.YCoordinate[userXint-1] < 0)
            {
                //The column is full
                return "reload";
            }
            Settings.Board[Settings.YCoordinate[userXint-1], userXint -1] = Settings.IsPlayerOne ? CellState.X : CellState.O ;
            Settings.NumTurns++;
            //IF win condition was fulfilled
            if (EndGame.GameOver(userXint, Settings))
            {
                GameOver = true;
                return "reload";
            }
            //IF board is full
            if (Settings.NumTurns == Settings.BoardHeight * Settings.BoardWidth)
            {
                 FullBoard = true; 
                 return "reload";
            }
            // IF not change player, save state and let's continue
            
            Settings.YCoordinate[userXint - 1]--;
            Settings.IsPlayerOne = !Settings.IsPlayerOne;
            
            RuntimeData.GameSettings = Settings;
            return "OK";
        }
    }
}