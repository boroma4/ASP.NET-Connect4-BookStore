using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SaveName = table.Column<string>(nullable: false),
                    SaveTime = table.Column<string>(nullable: false),
                    FirstPlayerName = table.Column<string>(nullable: false),
                    SecondPlayerName = table.Column<string>(nullable: false),
                    BoardHeight = table.Column<int>(nullable: false),
                    BoardWidth = table.Column<int>(nullable: false),
                    IsPlayerOne = table.Column<bool>(nullable: false),
                    NumTurns = table.Column<int>(nullable: false),
                    Ycoord = table.Column<string>(nullable: true),
                    GameBoard = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
