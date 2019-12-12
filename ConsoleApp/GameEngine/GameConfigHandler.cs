using System.Linq;
using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GameEngine
{
    public static class GameConfigHandler
    {
        private static readonly DbContextOptions _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(@"Data Source=D:\Databases\connect4.db").Options;
        
        public static void SaveConfig(GameSettings settings, int id = 0)
        {
                settings.Id = id;
                settings.YCoordinateString = JsonConvert.SerializeObject(settings.YCoordinate);
                settings.BoardString = JsonConvert.SerializeObject(settings.Board);
                
              
                var db = new AppDbContext(_options);
                
                if (db.Settings.Any(o => o.Id == id))
                {
                    db.Settings.Update(settings);
                }
                else 
                {
                    db.Settings.Add(settings);
                }
                db.SaveChanges();
        }

        public static GameSettings LoadConfig(int id = 0)
        {
            
            var db = new AppDbContext(_options);
            var res = db.Settings.Find(id);
            
            if (res != null)
            {
                res.Board = JsonConvert.DeserializeObject<CellState[,]>(res.BoardString);
                res.YCoordinate = JsonConvert.DeserializeObject<int[]>(res.YCoordinateString);
            }
            else res = new GameSettings();
        
            return res;
        }
    }
}