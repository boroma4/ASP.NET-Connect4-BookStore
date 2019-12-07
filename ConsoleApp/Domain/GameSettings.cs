using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace Domain
{
    public class GameSettings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } = 0;
        public string SaveName { get; set; } = "Empty";
        public string SaveTime { get; set; } = "N/A";
        
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstPlayerName { get; set; } = default!;
        
        [MinLength(2)]
        [MaxLength(30)]
        public string SecondPlayerName { get; set; } = "Bot Ricardo";

        public bool VersusBot { get; set; } = false;
        
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

        public (string name,string time) WebStrings()
        {
            return (SaveName,SaveTime);
        }
    }
}
