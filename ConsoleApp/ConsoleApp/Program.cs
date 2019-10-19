using System;
using System.Collections.Generic;
using System.Threading;
using GameEngine;
using MenuSystem;
using ConsoleUI;
using GamePlay;

namespace ConsoleApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading game...");
            Thread.Sleep(1000);
            AvailableSaves.PreLoadSaves();
            Console.Clear();
            var startMenu = new Menu(2)
            {
                Title = "Select Board Size",
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "1", new MenuItem()
                        {
                            Title = "Small board",
                            CommandToExecute = StartGame.SmallBoard
                        }
                    },
                    {
                        "2", new MenuItem()
                        {
                            Title = "Medium board",
                            CommandToExecute = StartGame.MediumBoard
                        }
                    },
                    {
                        "3", new MenuItem()
                        {
                            Title = "Large board",
                            CommandToExecute = StartGame.LargeBoard
                        }
                    },
                    {
                        "4", new MenuItem()
                        {
                            Title = "Custom size board",
                            CommandToExecute = StartGame.CustomSizeBoard
                        }
                    },
                }
            };

            var gameMenu = new Menu(1)
            {
                Title = "Start a new game of Connect4",
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "1", new MenuItem()
                        {
                            Title = "Computer starts(Not available yet)",
                            CommandToExecute = null
                        }
                    },
                    {
                        "2", new MenuItem()
                        {
                            Title = "Human starts(Not available yet)",
                            CommandToExecute = null
                        }
                    },
                    {
                        "3", new MenuItem()
                        {
                            Title = "Human against Human",
                            CommandToExecute = startMenu.Run
                        }
                    },
                }
            };
            var saveMenu = new Menu(1)
            {
                Title = "Select a save to load",
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "1", new MenuItem()
                        {
                            Title = AvailableSaves.Saves[0],
                            CommandToExecute =()=> StartGame.StartFromSave(0)
                        }
                    },
                    {
                        "2", new MenuItem()
                        {
                            Title = AvailableSaves.Saves[1],
                            CommandToExecute =()=> StartGame.StartFromSave(1)
                        }
                    },
                    {
                    "3", new MenuItem()
                    {
                        Title = AvailableSaves.Saves[2],
                        CommandToExecute =()=> StartGame.StartFromSave(2)
                    }
                },
                {
                    "4", new MenuItem()
                    {
                        Title = AvailableSaves.Saves[3],
                        CommandToExecute =()=> StartGame.StartFromSave(3)
                    }
                }
                
                }
            };
            var menu0 = new Menu(0)
            {
                Title = "Connect4 Main Menu",
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "S", new MenuItem()
                        {
                            Title = "Start new game",
                            CommandToExecute = gameMenu.Run
                        }
                    },
                    {
                        "L", new MenuItem()
                        {
                            Title = "Load game",
                            CommandToExecute =saveMenu.Run
                        }
                    }
                }
            };
            menu0.Run();
        }
        
    }
}
