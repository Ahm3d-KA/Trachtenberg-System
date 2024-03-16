using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trachtenberg_System.Data.UserData
{
    /// <inheritdoc />
    public partial class addotherhighscorse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MultiplicationExpertTestScore",
                table: "HighScores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MultiplicationHardTestScore",
                table: "HighScores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MultiplicationLegendTestScore",
                table: "HighScores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MultiplicationMediumTestScore",
                table: "HighScores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MultiplicationExpertTestScore",
                table: "HighScores");

            migrationBuilder.DropColumn(
                name: "MultiplicationHardTestScore",
                table: "HighScores");

            migrationBuilder.DropColumn(
                name: "MultiplicationLegendTestScore",
                table: "HighScores");

            migrationBuilder.DropColumn(
                name: "MultiplicationMediumTestScore",
                table: "HighScores");
        }
    }
}
