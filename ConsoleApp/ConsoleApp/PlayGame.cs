using System;
using ConsoleUI;
using GameEngine;
using SaveLoader;

namespace ConsoleApp
{
    public  static class PlayGame
    {
        internal static string PlayTheGame(GameSettings settings, bool loaded = false)
        {
            if (settings == null) return "";
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
                var name = "Autosave" +"("+settings.FirstPlayerName + "-" + settings.SecondPlayerName+")";
                Saver.SaveGame(settings,saveName:name);
                Console.Clear();
                GameUI.PrintBoard(game);
                var userXint = -1;
                var usedLetter = false;
                do
                {
                    Console.WriteLine("Press X to exit to main menu. Press S to save the game");
                    Console.WriteLine ("Enter column number, " 
                                       + (settings.IsPlayerOne ? $"{settings.FirstPlayerName}" : $"{settings.SecondPlayerName}" ));
                    Console.Write(">");
                    var userInput = Console.ReadLine() ?? "null";
                    if (userInput.ToUpper() == "S")
                    {
                         name = settings.FirstPlayerName + "-" + settings.SecondPlayerName;
                        Saver.SaveGame(settings,name,false);
                        GameUI.PrintBoard(game);
                        usedLetter = true;
                    }
                    else if (userInput.ToUpper() == "X")
                    {  
                        name = "Autosave" +"("+settings.FirstPlayerName + "-" + settings.SecondPlayerName+")";
                        Saver.SaveGame(settings,saveName:name);
                        return "";
                    }

                    if (!int.TryParse(userInput, out userXint) && !usedLetter)
                    {
                        Console.WriteLine($"{userInput} is not a number!");
                        userXint = -1;
                    }
                    else if (userXint > settings.BoardWidth) userXint = -1;
                    usedLetter = false;
                    
                } while (userXint < 1 || settings.YCoordinate[userXint-1] < 0);
                
                
                if (game.Move(settings.YCoordinate[userXint-1], userXint-1,settings) == "Ok")
                {
                    MakeAMove(settings,userXint,game);
                }
                
                done = settings.NumTurns == settings.BoardHeight*settings.BoardWidth;
                 
            } while (!done);
            
            GameUI.PrintBoard(game);
            Console.WriteLine("Game Over\n" + "Press any key to go back to menu");
            Console.ReadKey();
            Console.Clear();
            return "";
        }

        private static void MakeAMove(GameSettings settings,int userXint,Game game)
        {
            settings.NumTurns++;
            settings.YCoordinate[userXint - 1]--;
            settings.IsPlayerOne = !settings.IsPlayerOne;
            settings.Board = game.GetBoardCopy();
        }
        
    }
}