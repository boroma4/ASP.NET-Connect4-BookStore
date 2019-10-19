using Newtonsoft.Json;

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