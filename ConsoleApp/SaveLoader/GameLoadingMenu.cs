using System;
using System.Collections.Generic;
using GameEngine;

namespace SaveLoader
{
    public static class GameLoadingMenu
    {

        public static GameSettings DisplaySaveOptions()
        {
            Console.WriteLine("Select a save for loading");
            Console.WriteLine("===========================");
            foreach (var Pair in PreLoadSaves())
            {
                Console.WriteLine(Pair.Key+ ") " + Pair.Value.SaveName +" " +Pair.Value.SaveTime);
            }
           
            var res = -1;
            do
            {
                Console.WriteLine("Please select save number");
                Console.Write(">");
                var choice = Console.ReadLine();
                if (!int.TryParse(choice, out res))
                {
                    Console.WriteLine("Enter a number please");
                    res = -1;
                }
                else if (res > 5)
                {
                    res = -1;
                }
            } while (res<1 || PreLoadSaves()[res].SaveName == "Empty");

            return PreLoadSaves()[res];
        }
        private static Dictionary<int,GameSettings> PreLoadSaves()
        {
            var saves = new Dictionary<int,GameSettings>(4);
            saves.Add(1,GameConfigHandler.LoadConfig());
            for (var i = 2; i < 5; i++)
            {
                saves.Add(i,GameConfigHandler.LoadConfig($"{i}.json"));
            }
            return saves;
        }
    }
}