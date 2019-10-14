namespace GameEngine
{
    public class GameSettings
    {
        public string SaveName { get; set; } = "Empty";
        public string SaveTime { get; set; } = "N/A";
        public string FirstPlayerName { get; set; } = "Player one";
        public string SecondPlayerName { get; set; } = "Player two";
        public int BoardHeight { get; set; } = 4;
        public int BoardWidth { get; set; } = 5;
        public bool IsPlayerOne { get; set; } = true;

        public int[] YCoordinate { get; set; }

        public CellState [,] Board { get; set; } = new CellState[4,5];
    }
}
