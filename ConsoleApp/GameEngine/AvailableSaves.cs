using System.Collections.Generic;

namespace GameEngine
{
    public static class AvailableSaves
    {
        private static readonly int MAXSAVES = 4;
        public static string[] Saves { get; set; }
        


        public static void PreLoadSaves()
        {
            Saves = new string[4];
            var save = new List<GameSettings>(4);
            for ( var i = 0; i < MAXSAVES; i++)
            {
                 save.Add(GameConfigHandler.LoadConfig($"{i}.json"));
                 Saves[i] = save[i].SaveName + " " + save[i].SaveTime;
            }
        }
    }
}