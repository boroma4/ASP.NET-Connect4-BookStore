using System;
using System.ComponentModel;
using GameEngine;

namespace ConsoleUI
{
    public static class GameUI
    {
        private const string VerticalSeparator = " | ";
        private const string HorizontalSeparator = "-";
        private const string CenterSeparator = "+";

        public static void PrintBoard(Game game)
        {
            Console.Clear();
            var board = game.GetBoardCopy();
            for (var yIndex = 0; yIndex < game.Heigth; yIndex++)
            {
                var line = "";
                
                for (var xIndex = 0; xIndex < game.Width; xIndex++)
                {
                    if (xIndex < game.Width )
                    {
                        line += VerticalSeparator;
                    }
                    line += GetSingleState(board[yIndex, xIndex]);
                }
                line += VerticalSeparator;
                Console.WriteLine(line);

                if (yIndex < (game.Heigth))
                {
                    line = "";
                    for (var xIndex = 0; xIndex <= game.Width; xIndex++)
                    {
                        if(xIndex>0){ line += HorizontalSeparator;}
                        line += " ";
                        line += CenterSeparator;
                        line += " ";
                    }
                    Console.WriteLine(line);
                }
                if (yIndex == (game.Heigth-1))
                {
                    line = "   ";
                    for (var xIndex = 0; xIndex < game.Width; xIndex++)
                    {
                        line += xIndex + 1;
                        line += "   ";
                    }
                    line += "\n";
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
