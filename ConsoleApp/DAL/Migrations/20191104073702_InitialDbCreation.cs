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
                    Id = table.Column<int>(nullable: false),
                    SaveName = table.Column<string>(nullable: true),
                    SaveTime = table.Column<string>(nullable: true),
                    FirstPlayerName = table.Column<string>(nullable: true),
                    SecondPlayerName = table.Column<string>(nullable: true),
                    BoardHeight = table.Column<int>(nullable: false),
                    BoardWidth = table.Column<int>(nullable: false),
                    IsPlayerOne = table.Column<bool>(nullable: false),
                    NumTurns = table.Column<int>(nullable: false),
                    YCoordinateString = table.Column<string>(nullable: true),
                    BoardString = table.Column<string>(nullable: true)
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
