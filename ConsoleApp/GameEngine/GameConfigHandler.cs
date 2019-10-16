using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GameEngine
{
    public static class GameConfigHandler
    {
        
       
        public static int SaveConfig(GameSettings settings, string fileName = "0.json")
            {
                using (var writer = System.IO.File.CreateText(fileName))
                {
                    var jsonString = JsonConvert.SerializeObject(settings);
                    writer.Write(jsonString);
                    Console.WriteLine(jsonString);
                }

                return 0;
            }

        public static GameSettings LoadConfig(string fileName = "0.json")
        {
            if (System.IO.File.Exists(fileName))
            {
                var jsonString = System.IO.File.ReadAllText(fileName);
                var res = JsonConvert.DeserializeObject<GameSettings>(jsonString);
                return res;
            }

            return new GameSettings();
        }


    }
}