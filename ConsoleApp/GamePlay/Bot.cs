using System;
using System.Collections.Generic;
using System.Linq;
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
                    var canHelpHumanWin = false;
                    var timeout = 0;
                    var colsWithSpace = new List<int>();

                    for (var i = 0; i < settings.BoardWidth; i++)
                    {
                        if (settings.YCoordinate[i] >= 0)
                        {
                            colsWithSpace.Add(i + 1);
                        }
                    }
                    do
                    {
                        do 
                        {
                            // don't random among columns that have no space
                            var randColIndex = random.Next(colsWithSpace.Count);
                            botX = colsWithSpace[randColIndex];

                        } while (settings.YCoordinate[botX-1] < 0);

                        // fake a turn with selected coordinate
                        settings.Board[settings.YCoordinate[botX-1], botX-1] = CellState.O;
                        settings.YCoordinate[botX-1]--;
            
                        canHelpHumanWin = CheckIfCanWin(false, settings).Item1;
                        
                        // restore the board to what it was
                        settings.YCoordinate[botX-1]++;
                        settings.Board[settings.YCoordinate[botX-1], botX-1] = CellState.Empty;
                   
                        timeout ++ ;

                    } while (canHelpHumanWin && timeout < 1000);
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