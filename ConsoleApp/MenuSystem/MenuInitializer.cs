using System.Collections.Generic;
using GameEngine;
using GamePlay;

namespace MenuSystem
{
    public static class MenuInitializer
    {
        const string LoadMenuTitle = "Load game";
        internal const string SaveSelectionMenuTitle = "Select a save to load";
        internal const string StartMenuTitle = "Select Board Size";
        internal const string Board = "board";

        public static void Run()
        {
            var startPvCMenuB = new Menu(2)
            {
                Title = StartMenuTitle,
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "1", new MenuItem()
                        {
                            Title = "Small "+Board,
                            CommandToExecute =()=> StartGame.SmallBoard(true,true)
                        }
                    },
                    {
                        "2", new MenuItem()
                        {
                            Title = "Medium "+Board,
                            CommandToExecute =()=> StartGame.MediumBoard(true,true)
                        }
                    },
                    {
                        "3", new MenuItem()
                        {
                            Title = "Large "+Board,
                            CommandToExecute =()=> StartGame.LargeBoard(true,true)
                        }
                    },
                    {
                        "4", new MenuItem()
                        {
                            Title = "Custom size "+Board,
                            CommandToExecute =()=> StartGame.CustomSizeBoard(true,true)
                        }
                    },
                }
            };
            var startPvCMenuA = new Menu(2)
            {
                Title = StartMenuTitle,
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "1", new MenuItem()
                        {
                            Title = "Small "+Board,
                            CommandToExecute =()=> StartGame.SmallBoard(true)
                        }
                    },
                    {
                        "2", new MenuItem()
                        {
                            Title = "Medium "+Board,
                            CommandToExecute =()=> StartGame.MediumBoard(true)
                        }
                    },
                    {
                        "3", new MenuItem()
                        {
                            Title = "Large "+Board,
                            CommandToExecute =()=> StartGame.LargeBoard(true)
                        }
                    },
                    {
                        "4", new MenuItem()
                        {
                            Title = "Custom size "+Board,
                            CommandToExecute =()=> StartGame.CustomSizeBoard(true)
                        }
                    },
                }
            };
            var startPvPMenu = new Menu(2)
            {
                Title = StartMenuTitle,
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "1", new MenuItem()
                        {
                            Title = "Small "+Board,
                            CommandToExecute =()=> StartGame.SmallBoard()
                        }
                    },
                    {
                        "2", new MenuItem()
                        {
                            Title = "Medium "+Board,
                            CommandToExecute =()=> StartGame.MediumBoard()
                        }
                    },
                    {
                        "3", new MenuItem()
                        {
                            Title = "Large "+Board,
                            CommandToExecute =()=> StartGame.LargeBoard()
                        }
                    },
                    {
                        "4", new MenuItem()
                        {
                            Title = "Custom size "+Board,
                            CommandToExecute =()=> StartGame.CustomSizeBoard()
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
                            Title = "Computer starts",
                            CommandToExecute = startPvCMenuB.Run
                        }
                    },
                    {
                        "2", new MenuItem()
                        {
                            Title = "Human starts",
                            CommandToExecute = startPvCMenuA.Run
                        }
                    },
                    {
                        "3", new MenuItem()
                        {
                            Title = "Human against Human",
                            CommandToExecute = startPvPMenu.Run
                        }
                    },
                }
            };
            var saveMenu = new Menu(1)
            {
                Title = SaveSelectionMenuTitle,
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
                            Title = LoadMenuTitle,
                            CommandToExecute =saveMenu.Run
                        }
                    }
                }
            };
            menu0.Run();
        }
    }
}