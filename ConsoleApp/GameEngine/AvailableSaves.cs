using System.Collections.Generic;
using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace GameEngine
{
    public static class AvailableSaves
    {
        public static readonly int MAXSAVES = 4;
        public static string[] Saves { get; set; }= new string[4];
        


        public static void PreLoadSaves()
        {
            var dbOption = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(@"Data Source=D:\Databases\connect4.db").Options;
            var ctx = new AppDbContext(dbOption);
            
            ctx.Database.EnsureCreated();
            
                var save = new List<GameSettings>(4);
            for ( var i = 0; i < MAXSAVES; i++)
            {
                 save.Add(GameConfigHandler.LoadConfig(i));
                 Saves[i] = save[i].ToString();
            }
        }
    }
}