using System.Collections.Generic;

namespace GameEngine
{
    public static class AvailableSaves
    {
        private static readonly int MAXSAVES = 4;
        public static string[] Saves { get; set; }= new string[4];
        


        public static void PreLoadSaves()
        {
            var save = new List<GameSettings>(4);
            for ( var i = 0; i < MAXSAVES; i++)
            {
                 save.Add(GameConfigHandler.LoadConfig($"{i}.json"));
                 Saves[i] = save[i].SaveName + " " + save[i].SaveTime;
            }
        }
    }
}