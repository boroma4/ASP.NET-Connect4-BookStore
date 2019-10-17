using System;
using GameEngine;

namespace GamePlay
{
    public class EndGame
    {
        private static int _inLine = 1;
        const int legalMoves = 3;
        private static int count = 0;

        public static bool GameOver(int x, GameSettings settings)
        {
            return LineCrossed(x,settings);
        }
        private static bool LineCrossed(int x, GameSettings settings)
        {
            var board = settings.Board;
            var yCoordinate = settings.YCoordinate ;
            var cellstate = settings.IsPlayerOne ? CellState.X : CellState.O;
            var xCoordinate = x;
            var y = yCoordinate[xCoordinate-1];

            while (count < legalMoves && xCoordinate <settings.BoardWidth )
            {
                if (board[y,xCoordinate]==cellstate)
                {
                    _inLine++;
                    xCoordinate++;
                }
                count++;
            }
            xCoordinate = x-2;
            y = yCoordinate[xCoordinate+1];
            count = 0;
            while ( count < legalMoves && xCoordinate >= 0)
            {
                if (board[y,xCoordinate]==cellstate)
                {
                    _inLine++;
                    xCoordinate--;
                }
                count++;
                 
            }
            return _inLine == 4;
        }
        private static bool ColumnCrossed()
        {

            return true;
        }
        private static bool DiagonalCrossed()
        {

            return true;
        }
    }
}