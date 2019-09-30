using System;
using System.ComponentModel;
using GameEngine;

namespace ConsoleUI
{
    public static class GameUi
    {
        private static readonly string _verticalSeparator = "|";
        private static readonly string _horizontalSeparator = "--";
        private static readonly string _centrlaSeparator = "+";


        public static void PrintBoard(Game game )
        {
            var board = game.GetBoardCopy();
            for (int y = 0; y < game.Heigth; y++)
            {
                var line = "";
                for (int x = 0; x < game.Width; x++)
                {
                    line = line + " " + GetSingleState(board[x, y]) + " ";
                    if (x < game.Width - 1)
                    {
                        line = line + _verticalSeparator;
                    }
                }
                Console.WriteLine(line);
                if (y < game.Heigth - 1)
                {
                    line = "";
                    for (int xIndex = 0; xIndex < game.Width; xIndex++)
                    {
                        line = line + _horizontalSeparator;
                        if (xIndex < game.Width - 1)
                        {
                            line = line + _horizontalSeparator ;
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
                case CellState.Empty :
                    return " ";
                case CellState.O :
                    return "O";
                case CellState.X :
                    return "X";
                default:
                    throw new InvalidEnumArgumentException("Unknown enum option");
            }
        }
    }
}