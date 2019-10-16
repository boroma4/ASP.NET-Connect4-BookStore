using System;
using GameEngine;

namespace GamePlay
{
    public  static class StartGame
    {

        public static string SmallBoard()
        {
            var settings = SettingsSetup(4, 5);
            PlayGame.PlayTheGame(settings);
            return "";
        }

        public static string MediumBoard()
        {
            var settings = SettingsSetup(7, 8);
            PlayGame.PlayTheGame(settings);
            return "";
        }

        public static string LargeBoard()
        {
            var settings = SettingsSetup(7, 10);
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
            var settings = SettingsSetup(userH, userW); 

            PlayGame.PlayTheGame(settings);
            return "";
        }
        public static string StartFromSave (int slot )
        {
            if (AvailableSaves.Saves[slot] != "Empty")
            {
                PlayGame.PlayTheGame(GameConfigHandler.LoadConfig($"{slot}.json"), true);
            }

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

        private static string UserName(bool firstPlayer = true)
        {
            Console.Clear();
            Console.WriteLine("Enter " + (firstPlayer?"first":"second")+" player's name");
            Console.Write(">");
            var name = Console.ReadLine();
            Console.Clear();
            return name;
        }

        private static GameSettings SettingsSetup(int height, int width)
        {
            var settings = new GameSettings
            {
                BoardHeight = height,
                BoardWidth = width,
                FirstPlayerName = UserName(),
                SecondPlayerName = UserName(false),
                Board = new CellState[height, width]
            };
            settings.YCoordinate = new int[settings.BoardWidth];
            
            return settings;
        }
        
    }
}