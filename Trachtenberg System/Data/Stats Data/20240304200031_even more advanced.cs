using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trachtenberg_System.Data.StatsData
{
    /// <inheritdoc />
    public partial class evenmoreadvanced : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HighScoresId",
                table: "UserStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HighScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserStatsId = table.Column<int>(type: "int", nullable: false),
                    MultiplicationEasyTest = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighScores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HighScores");

            migrationBuilder.DropColumn(
                name: "HighScoresId",
                table: "UserStats");
        }
    }
}
