using System.Text.Json;

namespace GameEngine
{
    public static class GameConfigHandler
    {
        public static void SaveConfig(GameSettings settings, string fileName = "autosave.json")
            {
                using (var writer = System.IO.File.CreateText(fileName))
                {
                    var jsonString = JsonSerializer.Serialize(settings);
                    writer.Write(jsonString);
                }
            }

            public static GameSettings LoadConfig(string fileName = "autosave.json")
            {
                if (System.IO.File.Exists(fileName))
                {
                    var jsonString = System.IO.File.ReadAllText(fileName);
                    var res = JsonSerializer.Deserialize<GameSettings>(jsonString);
                    return res;
                }
                return new GameSettings();
            }
        
    }
}