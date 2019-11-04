using System;
using System.Diagnostics;
using Domain;

namespace GameEngine
{
    public class Game
    {
        // null, O
        private CellState[,] Board { get; set; }
        public int Width { get; }
        public int Heigth { get; }
        
        
        public Game(GameSettings settings)
        {
            if (settings.BoardWidth < 4 || settings.BoardHeight < 4)
            {
                throw new ArgumentException("Board size has to be at least 4x4");
            }

            Heigth = settings.BoardHeight;
            Width = settings.BoardWidth;
            Board = settings.Board;
        }

        public CellState[,] GetBoardCopy()
        {
            var result = new CellState[Heigth, Width];
            Array.Copy(Board,result,Board.Length);
            return result;
        }

        public string Move(int posY, int posX,GameSettings settings)
        {
            if (Board[posY, posX] != CellState.Empty)
            {
                return "Copy";
            }
            Board[posY, posX] = settings.IsPlayerOne ? CellState.X : CellState.O ;
            return "Ok";
        }
    }

}