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
            int[] Yint= new int [w];
            for (int i = 0; i < w; i++)
            {
                Yint[i] = h-1;
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
                    Console.WriteLine("Enter column number");
                    Console.Write(">");
                    var userX = Console.ReadLine();
                    if(Yint[userXint] < 0) Console.WriteLine("This column is full!");
                    if (!int.TryParse(userX, out userXint))
                    {
                        Console.WriteLine($"{userX} is not a number!");
                        userXint = -1;
                    }
                    else if (userXint > w) userXint = -1;
                } while (userXint < 0 || Yint[userXint] < 0);
                
                if (game.Move(Yint[userXint], userXint) == "Ok")
                {
                    turn++;
                    Yint[userXint]--;
                }
                
                done = turn == h*w;
            } while (!done);
            GameUI.PrintBoard(game);
            Console.WriteLine("Game Over");
            return "";
        }
    }
}