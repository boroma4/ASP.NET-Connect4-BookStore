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
            Console.Clear();
            var done = false;
            do
            {
                Console.Clear();
                GameUI.PrintBoard(game);
                var userXint = -1;
                do
                {
                    Console.WriteLine("Press 0 to exit the game.");
                    Console.WriteLine ("Enter column number, " 
                                       + (settings.IsPlayerOne ? $"{settings.FirstPlayerName}" : $"{settings.SecondPlayerName}" ));
                    Console.Write(">");
                    var userX = Console.ReadLine();
                    if (!int.TryParse(userX, out userXint))
                    {
                        Console.WriteLine($"{userX} is not a number!");
                        userXint = -1;
                    }
                    else if (userXint > settings.BoardWidth) userXint = -1;
                    else if(userXint == 0)
                    {
                        GameConfigHandler.SaveConfig(settings);
                        return "";
                    }
                    else if(userXint == 69)
                    {
                        var name = settings.FirstPlayerName +"-" +settings.SecondPlayerName;
                        settings.SaveName = name;
                        settings.SaveTime = DateTime.Now.ToString("MM/dd/yyyy H:mm");
                        GameConfigHandler.SaveConfig(settings,"1.json");
                    }
//TODO Maybe create a new class where I pass this name, So i Can use it in Menu
                } while (userXint < 1 || settings.YCoordinate[userXint-1] < 0);
                
                if (game.Move(settings.YCoordinate[userXint-1], userXint-1,settings) == "Ok")
                {
                    turn++;
                    settings.YCoordinate[userXint-1]--;
                    settings.IsPlayerOne = !settings.IsPlayerOne;
                    settings.Board = game.GetBoardCopy();
                    settings.SaveTime = DateTime.Now.ToString("MM/dd/yyyy H:mm");
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
//TODO Add Manual Save 
//TODO Refactor this
    }
}