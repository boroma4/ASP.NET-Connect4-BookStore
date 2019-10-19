using System;
using GameEngine;

namespace GamePlay
{
    public static class EndGame
    {
        const int LegalMoves = 3;

        public static bool GameOver(int x, GameSettings settings)
        {
            return LineCrossed(x,settings) || ColumnCrossed(x,settings);
        }
        private static bool LineCrossed(int x, GameSettings settings)
        {
            var inLine = 1;
            var count = 0;
            var board = settings.Board;
            var cellstate = settings.IsPlayerOne ? CellState.X : CellState.O; 
            var xCoordinate = x;  //x one square to the right of input
            var y = settings.YCoordinate[xCoordinate-1];// y of the input
            // Check 3 squares to the right of the input one 
            while (count < LegalMoves && xCoordinate <settings.BoardWidth )
            {
                if (board[y,xCoordinate]==cellstate)
                {
                    inLine++;
                    xCoordinate++;
                }
                count++;
            }
            xCoordinate = x-2; //x one square to the left of input
            y = settings.YCoordinate[xCoordinate+1]; // y of the input
            count = 0;
            // Check 3 squares to the left of the input 
            while ( count < LegalMoves && xCoordinate >= 0)
            {
                if (board[y,xCoordinate]==cellstate)
                {
                    inLine++;
                    xCoordinate--;
                }
                count++;
            }
            return inLine >= 4;
        }
        private static bool ColumnCrossed(int x, GameSettings settings)
        {
            var inLine = 1;
            var count = 0;
            var board = settings.Board;
            var cellstate = settings.IsPlayerOne ? CellState.X : CellState.O;
            var xCoordinate = x-1; // actual x of the input
            // no need to check square above in connect4
            var y = settings.YCoordinate[xCoordinate]+1; // one square below input (closer to max height)
            count = 0;
            while ( count < LegalMoves && y < settings.BoardHeight)
            {
                if (board[y,xCoordinate]==cellstate)
                {
                    inLine++;
                    y++;
                }
                count++;
            }
            return inLine >= 4;
        }
        private static bool DiagonalCrossed()
        {

            return true;
        }
    }
}