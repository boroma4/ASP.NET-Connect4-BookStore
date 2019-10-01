using System;
using System.ComponentModel;
using GameEngine;

namespace ConsoleUI
{
    public static class GameUI
    {
        private static readonly string _verticalSeparator = " | ";
        private static readonly string _horizontalSeparator = "-";
        private static readonly string _centerSeparator = "+";
        public static void PrintBoard(Game game)
        {
            Console.Clear();
            var board = game.GetBoardCopy();
            for (int yIndex = 0; yIndex < game.Heigth; yIndex++)
            {
                var line = "";
                for (int xIndex = 0; xIndex < game.Width; xIndex++)
                {
                    line = line + GetSingleState(board[yIndex, xIndex]);
                    if (xIndex < game.Width - 1)
                    {
                        line = line + _verticalSeparator;
                    }
                    

                }
                Console.WriteLine(line);

                if (yIndex < (game.Heigth-1))
                {
                    line = "";
                    for (int xIndex = 0; xIndex < game.Width; xIndex++)
                    {
                        line = line + _horizontalSeparator;
                        line += " ";
                        if (xIndex < game.Width - 1)
                        {
                            line = line + _centerSeparator;
                            line += " ";
                        }
                    

                    }
                    Console.WriteLine(line);
                }
                
                
            }
            
        }

        public static string GetSingleState(CellState state)
        {
            switch (state)
            {
                case CellState.Empty:
                    return " ";
                case CellState.O:
                    return "O";
                case CellState.X:
                    return "X";
                default:
                    throw new InvalidEnumArgumentException("Unknown enum option");
            }
        }
    }
}
