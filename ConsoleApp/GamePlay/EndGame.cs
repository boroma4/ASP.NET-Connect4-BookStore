using Domain;
using GameEngine;

namespace GamePlay
{
    public static class EndGame
    {
       private const int LegalMoves = 3;

       private static int _inline;
       private static int _count;
       private static CellState[,] _board;
       private static CellState _state;


        public static bool GameOver(int x, GameSettings settings)
        {
            return LineCrossed(x, settings) || ColumnCrossed(x, settings) || DiagonalCrossed(x, settings);
        }

        private static bool LineCrossed(int x, GameSettings settings)
        {
            CheckInitialize(settings);
            
            var xCoordinate = x; //x one square to the right of input
            var y = settings.YCoordinate[xCoordinate - 1]; // y of the input
            // Check 3 squares to the right of the input one 
            while (_count < LegalMoves && xCoordinate < settings.BoardWidth)
            {
                if (_board[y, xCoordinate] == _state)
                {
                    _inline++;
                    xCoordinate++;
                }
                _count++;
            }

            xCoordinate = x - 2; //x one square to the left of input
            y = settings.YCoordinate[xCoordinate + 1]; // y of the input
            _count = 0;
            // Check 3 squares to the left of the input 
            while (_count < LegalMoves && xCoordinate >= 0)
            {
                if (_board[y, xCoordinate] == _state)
                {
                    _inline++;
                    xCoordinate--;
                }
                _count++;
            }

            return _inline >= 4;
        }

        private static bool ColumnCrossed(int x, GameSettings settings)
        {
            CheckInitialize(settings);
            
            var xCoordinate = x - 1; // actual x of the input
            // no need to check square above in connect4
            var y = settings.YCoordinate[xCoordinate] + 1; // one square below input (closer to max height)
            _count = 0;
            while (_count < LegalMoves && y < settings.BoardHeight)
            {
                if (_board[y, xCoordinate] == _state)
                {
                    _inline++;
                    y++;
                }
                _count++;
            }

            return _inline >= 4;
        }

        private static bool DiagonalCrossed(int x, GameSettings settings)
        { 
            CheckInitialize(settings);
            var y = 0;

            var xCoordinate = x; //x one square to the right of input

            if (xCoordinate < settings.BoardWidth) // might be redundant
            {
                y = settings.YCoordinate[xCoordinate - 1] - 1; // y one square above
                // Diagonally check 3 squares to the right of the input one 
                while (_count < LegalMoves && y >= 0 && xCoordinate < settings.BoardWidth && y < settings.BoardHeight)
                {
                    if (_board[y, xCoordinate] == _state)
                    {
                        _inline++;
                        xCoordinate++;
                        y--;
                    }
                    _count++;
                }
            }

            _count = 0;
            xCoordinate = x - 2; //x one square to the left of input
            if (xCoordinate >= 0)
            {
                y = settings.YCoordinate[xCoordinate + 1] + 1; // y one square below

                // Diagonally check 3 squares to the left of the input one 
                while (_count < LegalMoves && y < settings.BoardHeight && y >= 0 && xCoordinate >= 0)
                {
                    if (_board[y, xCoordinate] == _state)
                    {
                        _inline++;
                        xCoordinate--;
                        y++;
                    }
                    _count++;
                }
            }

            if (_inline >= 4) return true;

            _inline = 1;
            _count = 0;
            xCoordinate = x; //one square to the right 

            if (xCoordinate < settings.BoardWidth) 
            {
                y = settings.YCoordinate[xCoordinate - 1] + 1; // y one square below
                // Diagonally check 3 squares to the right of the input one 
                while (_count < LegalMoves && y >= 0 && xCoordinate < settings.BoardWidth && y < settings.BoardHeight)
                {
                    if (_board[y, xCoordinate] == _state)
                    {
                        _inline++;
                        xCoordinate++;
                        y++;
                    }
                    _count++;
                }
            }

            _count = 0;
            xCoordinate = x - 2; //x one square to the left of input
            if (xCoordinate >= 0)
            {
                y = settings.YCoordinate[xCoordinate + 1] - 1; // y one square upper

                // Diagonally check 3 squares to the left of the input one 
                while (_count < LegalMoves && y < settings.BoardHeight && y >= 0 && xCoordinate >= 0)
                {
                    if (_board[y, xCoordinate] == _state)
                    {
                        _inline++;
                        xCoordinate--;
                        y--;
                    }
                    _count++;
                }
            }
            return _inline >= 4;
        }
        private static void CheckInitialize(GameSettings settings)
        {
            _inline = 1; 
            _count = 0;
            _board = settings.Board;
            _state = settings.IsPlayerOne ? CellState.X : CellState.O;
        }
    }

}