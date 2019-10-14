namespace GameEngine
{
    public class GameSettings
    {
        public string PlayerName { get; set; } = "Player";
        public int BoardHeight { get; set; } = 4;
        public int BoardWidth { get; set; } = 5;
        public bool IsPlayerOne { get; set; } = true;

        public int[] YCoordinate { get; set; }

        public CellState [,] Board { get; set; } = new CellState[4,5];
    }
}
