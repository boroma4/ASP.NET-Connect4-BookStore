using System;
using System.Collections.Generic;
using GameEngine;
using GamePlay;

namespace MenuSystem
{
    public class Menu
    {
        private readonly int _menuLevel;
        
        private const string MenuCommandExit = "X";
        private const string MenuCommandReturnToPrevious = "P";
        private const string MenuCommandReturnToMain = "M";
        
        private Dictionary<string, MenuItem> _menuItemsDictionary = new Dictionary<string, MenuItem>();

        public Menu(int menuLevel = 0)
        {
            _menuLevel = menuLevel;
        }
        
        public string? Title { get; set; }
        
        public Dictionary<string, MenuItem> MenuItemsDictionary
        {
            get => _menuItemsDictionary;
            set
            {
                _menuItemsDictionary = value;
                if (_menuLevel >= 2)
                {
                    _menuItemsDictionary.Add(MenuCommandReturnToPrevious, 
                        new MenuItem(){Title = "Return to Previous Menu"});
                }
                if (_menuLevel >= 1)
                {
                    _menuItemsDictionary.Add(MenuCommandReturnToMain, 
                        new MenuItem(){Title = "Return to Main Menu"});
                }
                _menuItemsDictionary.Add(MenuCommandExit, 
                    new MenuItem(){ Title = "Exit"});
            }
        }

        public string Run()
        {
            
            if (Title == "Select a save to load")
            {
                MenuItemsDictionary.Clear();
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "1", new MenuItem()
                        {
                            Title = AvailableSaves.Saves[0],
                            CommandToExecute = () => StartGame.StartFromSave(0)
                        }
                    },
                    {
                        "2", new MenuItem()
                        {
                            Title = AvailableSaves.Saves[1],
                            CommandToExecute = () => StartGame.StartFromSave(1)
                        }
                    },
                    {
                        "3", new MenuItem()
                        {
                            Title = AvailableSaves.Saves[2],
                            CommandToExecute = () => StartGame.StartFromSave(2)
                        }
                    },
                    {
                        "4", new MenuItem()
                        {
                            Title = AvailableSaves.Saves[3],
                            CommandToExecute = () => StartGame.StartFromSave(3)
                        }
                    },
                };
            }
            var command = "";
            do
            {
                var returnCommand = "";
               
                Console.Clear();
                Console.WriteLine(Title);
                Console.WriteLine("========================");

                foreach (var menuItem in MenuItemsDictionary)
                {
                    Console.Write(menuItem.Key);
                    Console.Write(" ");
                    Console.WriteLine(menuItem.Value);
                }
                
                Console.WriteLine("----------");
                Console.Write(">");

                command = Console.ReadLine()?.Trim().ToUpper() ?? "";
             
                if (MenuItemsDictionary.ContainsKey(command))
                {
                    var menuItem = MenuItemsDictionary[command];
                    if (menuItem.CommandToExecute != null)
                    {
                        returnCommand = menuItem.CommandToExecute(); 
                    }
                    if ((Title == "Select a save to load" && (menuItem.Title != StartGame.EmptySaveName)&&(menuItem.Title != "Exit"))||
                        (Title == "Select Board Size" && menuItem.Title.Contains("board")) ) 
                    {
                        returnCommand = MenuCommandReturnToMain;
                    }
                }
                
                if (returnCommand == MenuCommandExit)
                {
                    command = MenuCommandExit;
                }

                if (returnCommand == MenuCommandReturnToMain)
                {
                    if (_menuLevel != 0)
                    {
                        command = MenuCommandReturnToMain;
                    }
                }
                
            } while (command != MenuCommandExit && 
                     command != MenuCommandReturnToMain && 
                     command != MenuCommandReturnToPrevious);
            
            return command;
        }
    }
}