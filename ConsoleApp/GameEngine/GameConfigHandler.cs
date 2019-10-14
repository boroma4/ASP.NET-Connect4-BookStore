using System;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GameEngine
{
    public static class GameConfigHandler
    {
        
       
        public static void SaveConfig(GameSettings settings, string fileName = "autosave.json")
            {
                using (var writer = System.IO.File.CreateText(fileName))
                {
                    var jsonString = JsonConvert.SerializeObject(settings);
                    writer.Write(jsonString);
                }
            }

            public static GameSettings LoadConfig(string fileName = "autosave.json")
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