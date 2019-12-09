using System;
using Domain;

namespace GamePlay
{
    public static class Bot
    {
        public static int MakeMove(GameSettings settings)
        {
            var botX = 0;
            var random = new Random();

            var (botCanWin,cell) = CheckIfCanWin(true, settings);

            if (botCanWin)
            {
                botX = cell;
            }
            else
            {
                var (humanCanWin, cellToBlock) = CheckIfCanWin(false, settings);

                if (humanCanWin)
                {
                    botX = cellToBlock;
                }
                else
                {
                    do 
                    { 
                        botX = random.Next(1, settings.BoardWidth);
                    } while (settings.YCoordinate[botX-1] < 1);
                }
            }
            return botX;
        }

        private static (bool,int) CheckIfCanWin(bool bot,GameSettings settings)
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
            return (false,0);
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