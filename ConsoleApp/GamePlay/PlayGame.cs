using System;
using System.Threading;
using ConsoleUI;
using Domain;
using GameEngine;

namespace GamePlay
{
      internal static class PlayGame
    {
        internal static void PlayTheGame(GameSettings settings, bool loaded = false)
        {
            if (settings == null) return ;
            var game = new Game(settings);
            if (!loaded)
            {
                for (var i = 0; i < settings.BoardWidth; i++)
                { 
                    settings.YCoordinate[i] = settings.BoardHeight-1;
                }
            }
            Console.Clear();
            bool done,playerWon;
            do
            {
                
                Saver.SaveGame(settings,true);
                Console.Clear();
                GameUI.PrintBoard(game);
                var userXint = -1;
                var usedLetter = false;
                if (!settings.VersusBot || (settings.VersusBot && settings.IsPlayerOne))
                {
                    do
                    {
                        Console.WriteLine("Press X to go back to main menu. Press S to save the game");
                        Console.WriteLine("Enter column number, "
                                          + (settings.IsPlayerOne
                                              ? $"{settings.FirstPlayerName}"
                                              : $"{settings.SecondPlayerName}"));
                        Console.Write(">");
                        var userInput = Console.ReadLine()?.Trim() ?? "null";
                        if (userInput.ToUpper() == "S")
                        {
                            Saver.SaveGame(settings, false);
                            GameUI.PrintBoard(game);
                            usedLetter = true;
                        }
                        else if (userInput.ToUpper() == "X")
                        {
                            return;
                        }

                        if (!int.TryParse(userInput, out userXint) && !usedLetter)
                        {
                            Console.WriteLine($"{userInput} is not a number!");
                            userXint = -1;
                        }
                        else if (userXint > settings.BoardWidth) userXint = -1;

                        usedLetter = false;

                    } while (userXint < 1 || settings.YCoordinate[userXint - 1] < 0);
                }
                else if(settings.VersusBot)
                {
                    Console.WriteLine("Bot is thinking...");
                    Thread.Sleep(2000);
                    userXint = GameAI.MakeMove(settings);

                }
                playerWon = EndGame.GameOver(userXint, settings);
                
                if (game.Move(settings.YCoordinate[userXint-1], userXint-1,settings) == "Ok")
                {
                    MakeAMove(settings,userXint,game);
                }
                // if no space or player has won
                done = (settings.NumTurns == settings.BoardHeight*settings.BoardWidth) || playerWon ; 

            } while (!done);
            
            GameUI.PrintBoard(game);
            Console.Write("Game Over! ");
            if (playerWon)
            {
                Console.Write("Player ");
                Console.WriteLine((settings.IsPlayerOne ? settings.SecondPlayerName : settings.FirstPlayerName) +" has won!");
            }
            else
            {
                Console.WriteLine("Board is full!");
            }
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadKey();
            Console.Clear();
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