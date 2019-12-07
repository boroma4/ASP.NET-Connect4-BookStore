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

        public GameSettings Settings { get; set; } = default!;

        public bool GameOver { get; set; } = false;

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
            Helper.GameSettings = Settings;
        }

        public IActionResult OnPost(int? userXint)
        {
            Settings = Helper.GameSettings;
            Saver.SaveGame(Settings,true);


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
            else
            {
               //Saver.SaveGame(Settings,false);
            }
            Settings = Helper.GameSettings;


            return Page();
        }

        private string MakeATurn( int userXint)
        {
            /*
             * MESS
             */
            //1. IF reached the top
            if (Settings.YCoordinate[userXint-1] < 0)
            {
                //SOME ERROR
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
            // IF not change player, save state and let's continue
            
            Settings.YCoordinate[userXint - 1]--;
            Settings.IsPlayerOne = !Settings.IsPlayerOne;
            
            Helper.GameSettings = Settings;
            return "OK";
        }
    }
}