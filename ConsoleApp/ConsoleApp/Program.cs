using System;
using System.Threading;
using GameEngine;
using MenuSystem;


namespace ConsoleApp
{
    static class Program
    {
     
        static void Main(string[] args)
        {
            Console.WriteLine("Loading game...");
            Thread.Sleep(500);
            AvailableSaves.PreLoadSaves();
            Console.Clear();
            MenuInitializer.Run();
        }
        
    }
}
