using System;
using System.Collections.Generic;
using GameEngine;

namespace SaveLoader
{
    public static class Loader
    {
        private static readonly int MAXSAVES = 4;

        public static GameSettings LoadAGame()
        {
            SaveMenu.DisplaySaveOptions();
            int res;
            var saves = PreLoadSaves();
            do
            { 
                res = SaveMenu.Menu(true);
                if (res == SaveMenu.backCommand) return null;

            } while (saves[res].SaveName == "Empty");

            return saves[res];
        }
        
        internal static Dictionary<int,GameSettings> PreLoadSaves()
        {
            var saves = new Dictionary<int, GameSettings>(4) {{0, GameConfigHandler.LoadConfig()}};
            for (var i = 1; i < MAXSAVES; i++)
            {
                saves.Add(i,GameConfigHandler.LoadConfig($"{i}.json"));
            }
            return saves;
        }
    }
}