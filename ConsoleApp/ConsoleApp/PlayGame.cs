using System;
using ConsoleUI;
using GameEngine;

namespace ConsoleApp
{
    public  static class PlayGame
    {
        internal static string PlayTheGame(GameSettings settings, bool loaded = false)
        {
            var turn = 0;
            var game = new Game(settings);
            if (!loaded)
            {
                for (var i = 0; i < settings.BoardWidth; i++)
                {
                    settings.YCoordinate[i] = settings.BoardHeight - 1;
                }
            }

            //TODO Save Board state after each turn
            Console.Clear();
            var done = false;
            do
            {
                Console.Clear();
                GameUI.PrintBoard(game);
                var userXint = -1;
                do
                {
                    Console.WriteLine ("Enter column number, Player " + (settings.IsPlayerOne ? "One" : "Two" ));
                    Console.Write(">");
                    var userX = Console.ReadLine();
                    if (!int.TryParse(userX, out userXint))
                    {
                        Console.WriteLine($"{userX} is not a number!");
                        userXint = -1;
                    }
                    else if (userXint > settings.BoardWidth) userXint = -1;
                } while (userXint < 1 || settings.YCoordinate[userXint-1] < 0);
                
                if (game.Move(settings.YCoordinate[userXint-1], userXint-1) == "Ok")
                {
                    turn++;
                    settings.YCoordinate[userXint-1]--;
                    settings.IsPlayerOne = !settings.IsPlayerOne;
                    settings.Board = game.GetBoardCopy();
                    GameConfigHandler.SaveConfig(settings);
                }
                done = turn == settings.BoardHeight*settings.BoardWidth;
            } while (!done);
            
            GameUI.PrintBoard(game);
            Console.WriteLine("Game Over\n" + "Press any key to go back to menu");
            Console.ReadKey();
            Console.Clear();
            return "";
        }
//TODO Add Exit/Manual Save conditions
    }
}
//TODO loaded columns are not working