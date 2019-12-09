using System;
using System.ComponentModel;
using Domain;
using GameEngine;

namespace GamePlay
{
    public  static class StartGame
    {
        public static readonly string EmptySaveName = "Empty N/A";

        public static string SmallBoard(BotConfig bcfg)
        {
            var settings = SettingsSetup(4, 5,bcfg);
            PlayGame.PlayTheGame(settings);
            return "";
        }

        public static string MediumBoard(BotConfig bcfg)
        {
            var settings = SettingsSetup(7, 8,bcfg);
            PlayGame.PlayTheGame(settings);
            return "";
        }

        public static string LargeBoard(BotConfig bcfg)
        {
            var settings = SettingsSetup(7, 10,bcfg);
            PlayGame.PlayTheGame(settings);
            return "";
        }
        public static string CustomSizeBoard(BotConfig bcfg)
        {
            Console.Clear();
            var userH =  BoardSideInput();
            Console.Clear();
            var userW = BoardSideInput(false);
            Console.Clear();
            var settings = SettingsSetup(userH, userW,bcfg); 

            PlayGame.PlayTheGame(settings);
            return "";
        }
        public static string StartFromSave (int slot)
        {
            if (AvailableSaves.Saves[slot] != EmptySaveName)
            {
                PlayGame.PlayTheGame(GameConfigHandler.LoadConfig(slot), true);
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
                else if (userInput > 10)
                {
                    Console.WriteLine("Side length can't' be bigger than 10!");
                    userInput = -1;
                }
            } while (userInput < 0);

            return userInput;
        }

        private static string UserName(bool firstPlayer = true)
        {
            var name = "";
            Console.Clear();
            do
            {
                Console.WriteLine("Enter " + (firstPlayer?"first":"second")+" player's name");
                Console.Write(">");
                name = Console.ReadLine()?.Trim()??"";
                if(name.Length == 0) { Console.WriteLine("Name can't be empty!");}
                if(name.Length >= 15) { Console.WriteLine("Name has to be 15 characters max!");}
            } while (name.Length == 0 || name.Length > 15);
            
            Console.Clear();
            return name;
        }

        private static GameSettings SettingsSetup(int height, int width,BotConfig bcfg)
        {
            var settings = new GameSettings
            {
                BoardHeight = height,
                BoardWidth = width,
                FirstPlayerName = UserName(),
                Board = new CellState[height, width],
                YCoordinate = new int[width],
            };
            switch (bcfg)
            {
                case BotConfig.NoBot:
                    settings.SecondPlayerName = UserName(false);
                    break;
                case BotConfig.BotStarts:
                    settings.VersusBot = true;
                    settings.IsPlayerOne = false;
                    break;
                case BotConfig.BotGoesSecond:
                    settings.VersusBot = true;
                    break;
                default:
                    throw new InvalidEnumArgumentException("Unknown bot config!");
            }
            
            return settings;
        }
        
    }
}