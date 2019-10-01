using System;
using ConsoleUI;
using GameEngine;

namespace ConsoleApp
{
    public class PlayGame
    {
        public static string SmallBoard()
        {
            StartGame(4, 5);
            return "";
        }

        public static string MediumBoard()
        {
            StartGame(7, 8);
            return "";
        }

        public static string LargeBoard()
        {
            StartGame(7, 10);
            return "";
        }
        public static string CustomSizeBoard()
        {
            Console.Clear();
            Console.WriteLine("Enter height of the board");
            Console.Write(">");
            var height = Console.ReadLine();
            Console.WriteLine("Enter width of the board");
            Console.Write(">");
            var width = Console.ReadLine();
            int.TryParse(height, out int h);
            int.TryParse(width, out int w);
            StartGame(h, w);
            return "";
        }
        private static string StartGame(int h, int w)
        {
            int turn = 0;
            var game = new Game(h,w);
            Console.Clear();
            var done = false;
            do
            {
                Console.Clear();
                GameUI.PrintBoard(game);
                var userXint = -1;
                var userYint = -1;
                do
                {
                    Console.WriteLine("Give me X value");
                    Console.Write(">");
                    var userX = Console.ReadLine();
                    if (!int.TryParse(userX, out userXint))
                    {
                        Console.WriteLine($"{userX} is not a number!");
                    }
                } while (userXint < 0);
                
                do
                {
                    Console.WriteLine("Give me Y value");
                    Console.Write(">");
                    var userY = Console.ReadLine();
                    if (!int.TryParse(userY, out userYint))
                    {
                        Console.WriteLine($"{userY} is not a number!");
                    }
                } while (userYint < 0);
  
                game.Move(userYint,userXint);
                turn++;
                done = turn == h*w;
            } while (!done);
            GameUI.PrintBoard(game);
            return "a";
        }
    }
}