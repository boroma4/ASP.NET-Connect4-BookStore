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
        public string FirstPlayerName { get; set; } = default!;
        public string SecondPlayerName { get; set; } = "Bot";
        public int BoardHeight { get; set; } = default!;
        public int BoardWidth { get; set; } = default!;
        public bool IsPlayerOne { get; set; } = true;

        [NotMapped]
        public int[] YCoordinate { get; set; } = {0};
        
        // add strings for saving those to the db
        [NotMapped]
        public CellState [,] Board { get; set; } = default!;
        public int NumTurns { get; set; } = default!;

        public string YCoordinateString { get; set; } = default!;

        public string BoardString { get; set; } = default!;


        public override string ToString()
        {
            return SaveName + " " +SaveTime;
        }
    }
}
