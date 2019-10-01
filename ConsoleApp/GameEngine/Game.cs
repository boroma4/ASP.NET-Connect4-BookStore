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
            if (width < 3 || height < 3)
            {
                throw new ArgumentException("Board size has to be at least 3x3");
            }
            //setBoardSize(ref width,ref height );
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

        public void Move(int posY, int posX)
        {
            if (posX > Width - 1) posX = Width - 1;
            if (posY > Heigth - 1) posY = Heigth - 1;
            if (posX < 0) posX = 0;
            if (posY < 0) posY = 0;
            
            if (Board[posY, posX] != CellState.Empty)
            {
                return;
            }
            Board[posY, posX] = _playerZeroMove ? CellState.X : CellState.O ;
            _playerZeroMove = !_playerZeroMove;
        }
    }

}