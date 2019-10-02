using System;
using System.Diagnostics;

namespace GameEngine
{
    public class Game
    {
        // null, O
        private CellState[,] Board { get; set; }
        public int Width { get; }
        public int Heigth { get; }

        private bool _playerZeroMove = false;


        
        public Game(int height, int width)
        {
            if (width < 4 || height < 4)
            {
                
                 throw new ArgumentException("Board size has to be at least 4x4");
            }
            Heigth = height;
            Width = width;
            Board = new CellState[height,width];
        }

        public CellState[,] GetBoardCopy()
        {
            var result = new CellState[Heigth, Width];
            Array.Copy(Board,result,Board.Length);
            return result;
        }

        public string Move(int posY, int posX)
        {
            if (Board[posY, posX] != CellState.Empty)
            {
                return "Copy";
            }
            Board[posY, posX] = _playerZeroMove ? CellState.X : CellState.O ;
            _playerZeroMove = !_playerZeroMove;
            return "Ok";
        }
    }

}