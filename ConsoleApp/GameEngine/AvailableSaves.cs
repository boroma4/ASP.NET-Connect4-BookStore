using System.Collections.Generic;
using DAL;
using Domain;

namespace GameEngine
{
    public static class AvailableSaves
    {
        private static readonly int MAXSAVES = 4;
        public static string[] Saves { get; set; }= new string[4];
        


        public static void PreLoadSaves()
        {
            using (var db = new AppDbContext())
            {
                var created = db.Database.EnsureCreated();
            }
            var save = new List<GameSettings>(4);
            for ( var i = 0; i < MAXSAVES; i++)
            {
                 save.Add(GameConfigHandler.LoadConfig(i));
                 Saves[i] = save[i].ToString();
            }
        }
    }
}