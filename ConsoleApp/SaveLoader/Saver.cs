using System;
using GameEngine;

namespace SaveLoader
{
    public static class Saver
    {
        public static  void SaveGame(GameSettings settings,string saveName,bool autoSave = true)
        {
            if (autoSave)
            {
                settings.SaveName = saveName;
                settings.SaveTime = DateTime.Now.ToString("MM/dd/yyyy H:mm:ss");
                if (settings.NumTurns != (settings.BoardHeight * settings.BoardWidth ))
                { 
                    GameConfigHandler.SaveConfig(settings);
                }
            }
            else
            {
                var slot = SlotSelector(settings);
                if (slot == SaveMenu.backCommand) return;
                settings.SaveName = saveName;
                settings.SaveTime = DateTime.Now.ToString("MM/dd/yyyy H:mm");
                GameConfigHandler.SaveConfig(settings, slot+".json");
            }
        }
        private static int SlotSelector(GameSettings settings)
        {
            SaveMenu.DisplaySaveOptions();
            var res = SaveMenu.Menu(false);
            return res;
        }
    }
}
//TODO Integrate MenuSystem.Menu here, or create something new so I can nicely move back while loading/saving + refactor