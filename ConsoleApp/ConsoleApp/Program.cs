using System;
using System.Collections.Generic;
using GameEngine;
using MenuSystem;
using ConsoleUI;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            
            var startMenu = new Menu(2)
            {
                Title = "Select Board Size",
                MenuItems = new List<MenuItem>()
                {
                    new MenuItem()
                    {
                        Command = "1",
                        Title = "Small board",
                        CommandToExecute = PlayGame.SmallBoard
                    },
                    new MenuItem()
                    {
                        Command = "2",
                        Title = "Medium board",
                        CommandToExecute = PlayGame.MediumBoard
                    },
                    new MenuItem()
                    {
                        Command = "3",
                        Title = "Big board",
                        CommandToExecute = PlayGame.LargeBoard
                    },
                    new MenuItem()
                    {
                        Command = "4",
                        Title = "Custom board",
                        CommandToExecute = PlayGame.CustomSizeBoard
                    },
                }
            };

            var gameMenu = new Menu(1)
            {
                Title = "Start a new game of Connect4",
                MenuItems = new List<MenuItem>()
                {
                    new MenuItem()
                    {
                        Command = "1",
                        Title = "Computer starts",
                        CommandToExecute = null
                    },
                    new MenuItem()
                    {
                        Command = "2",
                        Title = "Human starts",
                        CommandToExecute = null
                    },
                    new MenuItem()
                    {
                        Command = "3",
                        Title = "Human against Human",
                        CommandToExecute = startMenu.Run
                    },
                }
            };

            var menu0 = new Menu(0)
            {
                Title = "Connect4 Main Menu",
                MenuItems = new List<MenuItem>()
                {
                    new MenuItem()
                    {
                        Command = "S",
                        Title = "Start game",
                        CommandToExecute = gameMenu.Run
                    },
                }
            };
            menu0.Run();
        }
        
    }
}
