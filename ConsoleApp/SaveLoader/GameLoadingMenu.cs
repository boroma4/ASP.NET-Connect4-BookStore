using System;
using System.Collections.Generic;
using GameEngine;

namespace SaveLoader
{
    public static class GameLoadingMenu
    {
        private static readonly int MAXSAVES = 4;

        public static GameSettings LoadAGame()
        {
            DisplaySaveOptions();
            var res = -1;
            var saves = PreLoadSaves();
            do
            {
                Console.WriteLine("Please select a slot number");
                Console.Write(">");
                var choice = Console.ReadLine();
                if (!int.TryParse(choice, out res))
                {
                    Console.WriteLine("Enter a number please");
                    res = -1;
                }
                else if (res > 3)
                {
                    res = -1;
                }
            } while (res<0 || saves[res].SaveName == "Empty");

            return saves[res];
        }

        internal static void DisplaySaveOptions()
        {
            Console.WriteLine("Select a slot");
            Console.WriteLine("===========================");
            var saves = PreLoadSaves();
            foreach (var Pair in saves)
            {
                Console.WriteLine(Pair.Key+ ") " + Pair.Value.SaveName +" " +Pair.Value.SaveTime);
            }
        }
        internal static Dictionary<int,GameSettings> PreLoadSaves()
        {
            var saves = new Dictionary<int,GameSettings>(4);
            saves.Add(0,GameConfigHandler.LoadConfig());
            for (var i = 1; i < MAXSAVES; i++)
            {
                saves.Add(i,GameConfigHandler.LoadConfig($"{i}.json"));
            }
            return saves;
        }
    }
}