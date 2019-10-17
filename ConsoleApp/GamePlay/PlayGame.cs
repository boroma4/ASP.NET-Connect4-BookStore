using System;
using ConsoleUI;
using GameEngine;

namespace GamePlay
{
      static class PlayGame
    {
        internal static string PlayTheGame(GameSettings settings, bool loaded = false)
        {
            if (settings == null) return "";
            var game = new Game(settings);
            if (!loaded)
            {
                for (var i = 0; i < settings.BoardWidth; i++)
                {
                    settings.YCoordinate[i] = settings.BoardHeight-1;
                }
            }
            Console.Clear();
            bool done;
            var finished = false;
            do
            {
                
                Saver.SaveGame(settings,true);
                //Console.Clear();
                GameUI.PrintBoard(game);
                var userXint = -1;
                var usedLetter = false;
                
                do
                {
                    Console.WriteLine("Press X to exit current game. Press S to save the game");
                    Console.WriteLine ("Enter column number, " 
                                       + (settings.IsPlayerOne ? $"{settings.FirstPlayerName}" : $"{settings.SecondPlayerName}" ));
                    Console.Write(">");
                    var userInput = Console.ReadLine() ?? "null";
                    if (userInput.ToUpper() == "S")
                    {
                        Console.WriteLine(AvailableSaves.Saves);
                        Saver.SaveGame(settings,false);
                        GameUI.PrintBoard(game);
                        usedLetter = true;
                    }
                    else if (userInput.ToUpper() == "X")
                    {
                        //Saver.SaveGame(settings,true);
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
                    //finished = EndGame.GameOver(userXint, settings);
                   
                }
                done = settings.NumTurns == settings.BoardHeight*settings.BoardWidth ;

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

        private static void DeclareWinner()
        {
      
        }
        
    }
      
}