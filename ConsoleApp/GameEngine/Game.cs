using System;

namespace GameEngine
{
    public class Game
    {
        // null, O
        private CellState[,] Board { get; set; }
        public int Width { get; }
        public int Heigth { get; }

        private bool _playerZeroMove = false;


        
        public Game(int width = 7, int height = 6)
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
            if (Board[posY, posX] != CellState.Empty)
            {
                return;
            }
            Board[posY, posX] = _playerZeroMove ? CellState.X : CellState.O ;
            _playerZeroMove = !_playerZeroMove;
        }

        private void setBoardSize( ref int width, ref int heigth)
        {
            Console.WriteLine("Select board size :\n 1 - tiny, 2 - Small, 3 - Medium, 4 - Big, 5- Large");
             var size  = Console.ReadLine();
             Int32.TryParse(size, out int j);
            
            switch (j)
            {
                case 0 :
                    heigth = 4;
                    width = 5;
                    break;
                    
                case 1 :
                    heigth = 5;
                    width = 6;
                    break;
                
                case 2 :
                    heigth = 7;
                    width = 8;
                    break;
                
                case 3 :
                    heigth = 7;
                    width = 9;
                    break;
                
                case 4 :
                    heigth = 7;
                    width = 10;
                    break;
                default: 
                    throw new ArgumentException("Invalid board size");
                    break;
            }
            
        }
    }

}