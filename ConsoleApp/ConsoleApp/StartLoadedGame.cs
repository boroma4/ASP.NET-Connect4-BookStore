using GameEngine;

namespace ConsoleApp
{
    public class StartLoadedGame
    {
        public static string StartFromAutosave ()
        {
            var settings = GameConfigHandler.LoadConfig();
            PlayGame.PlayTheGame(settings);
            return "";
        }
    }
}