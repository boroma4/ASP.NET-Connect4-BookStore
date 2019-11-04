using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class GameSettings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Id { get; set; } = 0;
        public string SaveName { get; set; } = "Empty";
        public string SaveTime { get; set; } = "N/A";
        public string FirstPlayerName { get; set; } = "Player one";
        public string SecondPlayerName { get; set; } = "Player two";
        public int BoardHeight { get; set; } = 4;
        public int BoardWidth { get; set; } = 5;
        public bool IsPlayerOne { get; set; } = true;

        [NotMapped]
        public int[] YCoordinate { get; set; } = {0};
        
        // add strings for saving those to the db
        [NotMapped]
        public CellState [,] Board { get; set; } = new CellState[4,5];
        public int NumTurns { get; set; } = 0;

        public string? YCoordinateString { get; set; }
        
        public string? BoardString { get; set; }


        public override string ToString()
        {
            return SaveName + " " +SaveTime;
        }
    }
}
