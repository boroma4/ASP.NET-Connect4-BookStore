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
                Title = "Select board size",
                MenuItems = new List<MenuItem>()
                {
                    new MenuItem()
                    {
                        Command = "1",
                        Title = "Small",
                        CommandToExecute = TestGame
                    },
                    new MenuItem()
                    {
                        Command = "2",
                        Title = "Medium",
                        CommandToExecute = null
                    },
                    new MenuItem()
                    {
                        Command = "3",
                        Title = "Big",
                        CommandToExecute = null
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
                        CommandToExecute = startMenu.Run
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
                        CommandToExecute = null
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

        
         static string TestGame()
          {
              var game = new Game(3,3);
              var done = false;
  
              do
              {
                  Console.Clear();
                  GameUi.PrintBoard(game);
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
                  done = userXint == 0 && userYint == 0;
              } while (!done);
              return "GAME OVER";
          }
    }
}
