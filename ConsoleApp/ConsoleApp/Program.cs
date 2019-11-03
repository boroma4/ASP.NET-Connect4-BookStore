using System;
using System.Collections.Generic;
using System.Threading;
using GameEngine;
using MenuSystem;
using ConsoleUI;
using DAL;
using GamePlay;

namespace ConsoleApp
{
    static class Program
    {
     
        static void Main(string[] args)
        {
            GameSettings set = new GameSettings()
            {
                IsPlayerOne = false,
                SaveName = "2",
                SaveTime = "23",
                NumTurns = 3,
                FirstPlayerName = "aaa",
                SecondPlayerName = "bb",
            };
            Console.WriteLine("Loading game...");
            Thread.Sleep(500);
            AvailableSaves.PreLoadSaves();
            Console.Clear();
            MenuInitializer.Run();
        }
        
    }
}
