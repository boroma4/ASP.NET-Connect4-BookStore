using System;
using GameEngine;

namespace SaveLoader
{
    public static class Saver
    {
        public static void SaveGame(GameSettings settings,bool autoSave = true,string saveName = "Autosave")
        {
            if (autoSave)
            {
                settings.SaveName = saveName;
                settings.SaveTime = DateTime.Now.ToString("MM/dd/yyyy H:mm");
                if (settings.NumTurns != (settings.BoardHeight * settings.BoardWidth ))
                { 
                    GameConfigHandler.SaveConfig(settings);
                }
            }
            else
            {
                var slot = SlotSelector(settings);
                settings.SaveName = saveName;
                settings.SaveTime = DateTime.Now.ToString("MM/dd/yyyy H:mm");
                GameConfigHandler.SaveConfig(settings, slot+".json");
                Console.WriteLine("Game was successfully saved ");
            }
        }
        private static int SlotSelector(GameSettings settings)
        {
            var res = -1;
            GameLoadingMenu.DisplaySaveOptions();
            do
            {
                Console.WriteLine("Please select slot number");
                Console.Write(">");
                var choice = Console.ReadLine();
                if (!int.TryParse(choice, out res))
                {
                    Console.WriteLine("Enter a number please");
                    res = -1;
                }
                else if (res > 3 || res < 1)
                {
                    if(res == 0) { Console.WriteLine("You cannot overwrite an autosave!");}
                    res = -1;
                }
                else if (GameLoadingMenu.PreLoadSaves()[res].SaveName !="Empty")
                {
                    Console.WriteLine("Are you sure you want to overwrite this save?");
                    Console.WriteLine("Y - Yes\nN - No");
                    Console.Write(">");
                    var approval = Console.ReadLine()??"null";
                    if (approval.ToUpper() == "Y")
                    {
                        return res;
                    }
                    if(approval.ToUpper() == "N")
                    {
                        res = -1;
                    }
                }
            } while (res < 1 );

            return res;
        }
    }
}
//TODO Integrate MenuSystem.Menu here, so I can nicely move from save to save