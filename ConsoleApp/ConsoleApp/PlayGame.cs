using System;
using ConsoleUI;
using GameEngine;

namespace ConsoleApp
{
    public  static class PlayGame
    {
       
        
        internal static string PlayTheGame(GameSettings settings)
        {
            var turn = 0;
            var isPlayerOne = true;
            var game = new Game(settings);
            var yCoordinate= new int [settings.BoardWidth];
            for (var i = 0; i < settings.BoardWidth; i++)
            {
                yCoordinate[i] = settings.BoardHeight-1;
            }
            GameConfigHandler.SaveConfig(settings);
            Console.Clear();
            var done = false;
            do
            {
                Console.Clear();
                GameUI.PrintBoard(game);
                var userXint = -1;
                do
                {
                    Console.WriteLine ("Enter column number, Player " + (isPlayerOne ? "One" : "Two" ));
                    Console.Write(">");
                    var userX = Console.ReadLine();
                    if (!int.TryParse(userX, out userXint))
                    {
                        Console.WriteLine($"{userX} is not a number!");
                        userXint = -1;
                    }
                    else if (userXint > settings.BoardWidth) userXint = -1;
                } while (userXint < 1 || yCoordinate[userXint-1] < 0);
                
                if (game.Move(yCoordinate[userXint-1], userXint-1) == "Ok")
                {
                    turn++;
                    yCoordinate[userXint-1]--;
                    isPlayerOne = !isPlayerOne;
                }
                done = turn == settings.BoardHeight*settings.BoardWidth;
            } while (!done);
            
            GameUI.PrintBoard(game);
            Console.WriteLine("Game Over\n" + "Press any key to go back to menu");
            Console.ReadKey();
            Console.Clear();
            return "";
        }

    }
}