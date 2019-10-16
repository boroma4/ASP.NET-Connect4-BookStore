using System;
using System.Linq;

namespace GameEngine
{
    public static class Saver
    {
        public static  void SaveGame(GameSettings settings,bool autoSave)
        {
            if (autoSave)
            {
                var name = "Autosave" +"("+settings.FirstPlayerName + "-" + settings.SecondPlayerName+")";
                settings.SaveName = name;
                settings.SaveTime = DateTime.Now.ToString("MM/dd/yyyy H:mm:ss");
                if (settings.NumTurns != (settings.BoardHeight * settings.BoardWidth ))
                {

                    AvailableSaves.Saves[0] = settings.SaveName + " " +settings.SaveTime;
                    GameConfigHandler.SaveConfig(settings);
                }
            }
            else
            {
                var slot = SlotSelector(settings);
                if (slot == SaveMenu.BackCommand) return;
                var name = settings.FirstPlayerName + "-" + settings.SecondPlayerName;
                settings.SaveName = name;
                settings.SaveTime = DateTime.Now.ToString("MM/dd/yyyy H:mm:ss");
                AvailableSaves.Saves[slot] = settings.SaveName + " " +settings.SaveTime;
                GameConfigHandler.SaveConfig(settings, slot+".json");
            }
        }
        private static int SlotSelector(GameSettings settings)
        {
            SaveMenu.DisplaySaveOptions();
            var res = SaveMenu.Menu();
            return res;
        }
    }
}
//TODO Integrate MenuSystem.Menu here, or create something new so I can nicely move back while loading/saving + refactor