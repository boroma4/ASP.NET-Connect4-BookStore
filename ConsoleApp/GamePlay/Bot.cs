using System;
using Domain;

namespace GamePlay
{
    public static class Bot
    {
        private static int LastTurn { get; set; }
        public static int MakeMove(GameSettings settings)
        {
            var botX = 0;
            var random = new Random();

            var botCanWin = CanWin(true, settings);

            if (botCanWin.Item1 == true)
            {
                botX = botCanWin.Item2.Value;
            }
            else
            {
                var humanCanWin = CanWin(false, settings);
            
                if (humanCanWin.Item1 == true)
                {
                    botX = humanCanWin.Item2.Value;
                }
                else
                {
                    do 
                    { 
                        botX = random.Next(1, settings.BoardWidth);
                
                    } while (settings.YCoordinate[botX-1] < 1);
                }
            }

            LastTurn = botX;
            return botX;
        }

        private static (bool,int?) CanWin(bool bot,GameSettings settings)
        {
            InvertIfPlayer(bot,settings);

            for (var j = 1; j <= settings.BoardWidth; j++)
            {
                if (settings.YCoordinate[j - 1] > -1)
                {
                    if (EndGame.GameOver(j, settings))
                    {
                        InvertIfPlayer(bot, settings);
                        return (true, j);
                    }
                }
            }
            
            InvertIfPlayer(bot,settings);
            return (false,null);
        }

        private static void InvertIfPlayer(bool bot,GameSettings settings)
        {
            if (!bot)
            {
                settings.IsPlayerOne = !settings.IsPlayerOne;
            }
        }
    }
}