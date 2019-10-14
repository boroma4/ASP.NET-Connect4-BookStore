using System;
using GameEngine;

namespace ConsoleApp
{
    public class StartGame
    {
        
        public static string SmallBoard()
        {
            GameSettings settings = new GameSettings();
            settings.BoardHeight = 4;
            settings.BoardWidth = 5;
            PlayGame.PlayTheGame(settings);
            return "";
        }

        public static string MediumBoard()
        {
            GameSettings settings = new GameSettings();
            settings.BoardHeight = 7;
            settings.BoardWidth = 8;
            PlayGame.PlayTheGame(settings);
            return "";
        }

        public static string LargeBoard()
        {
            GameSettings settings = new GameSettings();
            settings.BoardHeight = 7;
            settings.BoardWidth = 10;
            PlayGame.PlayTheGame(settings);
            return "";
        }
        public static string CustomSizeBoard()
        {
            Console.Clear();
            var userH =  BoardSideInput();
            Console.Clear();
            var userW = BoardSideInput(false);
            Console.Clear();

            GameSettings settings = new GameSettings();
            settings.BoardHeight = userH;
            settings.BoardWidth = userW;
            PlayGame.PlayTheGame(settings);
            return "";
        }
        
        private static int BoardSideInput( bool heightMode = true)
        {
            var userInput = -1;
            do
            {
                Console.Write("Enter board ");
                Console.WriteLine(heightMode?"height: ":"width: ");
                Console.Write(">");
                var height = Console.ReadLine();
                if (!int.TryParse(height, out  userInput))
                {
                    Console.WriteLine("Enter a number!");
                    userInput = -1;
                }
                else if (userInput < 4)
                {
                    Console.WriteLine("Side length has to be at least 4!");
                    userInput = -1;
                }
            } while (userInput < 0);

            return userInput;
        }
    }
}