using System.Linq;
using DAL;
using Domain;
using Newtonsoft.Json;

namespace GameEngine
{
    public static class GameConfigHandler
    {
        public static int SaveConfig(GameSettings settings, int id = 0)
        {
                settings.Id = id;
                settings.YCoordinateString = JsonConvert.SerializeObject(settings.YCoordinate);
                settings.BoardString = JsonConvert.SerializeObject(settings.Board);

                using (var db = new AppDbContext())
                {
                    if (db.Settings.Any(o => o.Id == id))
                    {
                        db.Settings.Update(settings);
                    }
                    else 
                    {
                        db.Settings.Add(settings);
                    }
                    var count = db.SaveChanges();
                    
                }
                return 0;
            }

        public static GameSettings LoadConfig(int id = 0)
        {
            var res = new GameSettings();
            using (var db = new AppDbContext())
            {
                if (db.Settings.Any(o => o.Id == id))
                {
                   res = db.Settings.Find(id);
                   res.Board = JsonConvert.DeserializeObject<CellState[,]>(res.BoardString);
                   res.YCoordinate = JsonConvert.DeserializeObject<int[]>(res.YCoordinateString);
                   return res;
                }
            }

            return res;
        }


    }
}