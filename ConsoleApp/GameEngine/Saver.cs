using System;
using Domain;

namespace GameEngine
{
    public static class Saver
    {
        private const int BackCommand = 44;
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
                var slot = SlotSelector();
                if (slot == BackCommand) return;
                var name = settings.FirstPlayerName + "-" + settings.SecondPlayerName;
                settings.SaveName = name;
                settings.SaveTime = DateTime.Now.ToString("MM/dd/yyyy H:mm:ss");
                AvailableSaves.Saves[slot] = settings.SaveName + " " +settings.SaveTime;
                GameConfigHandler.SaveConfig(settings, slot);
            }
        }
        private static int SlotSelector()
        {
            DisplaySaveOptions();
            var res = Menu();
            return res;
        }
        
        private static int Menu()
        {
            var res = -1;
            do
            {
                Console.WriteLine("C-Cancel");
                Console.Write(">");
                var choice = Console.ReadLine()?.Trim()??"null";
                if (choice.ToUpper() == "C")
                {
                    res = BackCommand;
                    break;
                }
                if (!int.TryParse(choice, out res))
                {
                    Console.WriteLine("Enter a number please");
                    res = -1;
                }
                else if (res > 3 || res < 0)
                {
                    res = -1;
                }
                else if (res == 0)
                {
                    Console.WriteLine("You cannot overwrite an autosave!");
                    res = -1;
                }
                else if (AvailableSaves.Saves[res] != "Empty N/A")
                {
                    var escape = false;
                    do
                    {
                        Console.WriteLine("Are you sure you want to overwrite this save?");
                        Console.WriteLine("Y - Yes\nN - No");
                        Console.Write(">");
                        var approval = Console.ReadLine()?.Trim() ?? "null";
                        switch (approval.ToUpper())
                        {
                            case "Y":
                                return res;
                            case "N":
                                escape = true;
                                res = BackCommand;
                                break;
                        }

                    } while (!escape);
                }
            } while (res < 0 );
            return res;
        }
        
        private static void DisplaySaveOptions()
        {
            Console.WriteLine("Select a slot");
            Console.WriteLine("===========================");
            var saves = AvailableSaves.Saves;
            for (var i = 0; i<4; i++)
            {
                Console.WriteLine(i+") " +saves[i]);
            }
        }
    }
}