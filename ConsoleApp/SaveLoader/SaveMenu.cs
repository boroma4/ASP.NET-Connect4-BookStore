using System;

namespace SaveLoader
{
    public class SaveMenu
    {
        internal const int backCommand = 44;
        internal static int Menu(bool loading)
        {
            var res = -1;
            Console.WriteLine("C Cancel");
            do
            {
                Console.Write(">");
                var choice = Console.ReadLine()??"null";
                if (choice.ToUpper() == "C")
                {
                    res = backCommand;
                    break;
                }
                if (!int.TryParse(choice, out res))
                {
                    Console.WriteLine("Enter a number please");
                    res = -1;
                }
                else if (res > 3)
                {
                    res = -1;
                }
                else if (!loading)
                {
                    if (res == 0)
                    {
                        Console.WriteLine("You cannot overwrite an autosave!");
                        res = -1;
                    }
                    else if (Loader.PreLoadSaves()[res].SaveName != "Empty")
                    {
                        Console.WriteLine("Are you sure you want to overwrite this save?");
                        Console.WriteLine("Y - Yes\nN - No");
                        Console.Write(">");
                        var approval = Console.ReadLine() ?? "null";
                        switch (approval.ToUpper())
                        {
                            case "Y":
                                return res;
                            case "N":
                                res = -1;
                                break;
                        }
                    }
                }
            } while (res < 0 );

            return res;
        }
        
        internal static void DisplaySaveOptions()
        {
            Console.WriteLine("Select a slot");
            Console.WriteLine("===========================");
            var saves = Loader.PreLoadSaves();
            foreach (var Pair in saves)
            {
                Console.WriteLine(Pair.Key+ ") " + Pair.Value.SaveName +" " +Pair.Value.SaveTime);
            }
        }
    }
}