using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trachtenberg_System.Data.UserData
{
    /// <inheritdoc />
    public partial class adduserstatsmdoel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserStatsId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfTestsCompleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStats", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserStatsId",
                table: "AspNetUsers",
                column: "UserStatsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserStats_UserStatsId",
                table: "AspNetUsers",
                column: "UserStatsId",
                principalTable: "UserStats",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserStats_UserStatsId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserStats");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserStatsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserStatsId",
                table: "AspNetUsers");
        }
    }
}
