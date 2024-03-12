using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trachtenberg_System.Data.UserData
{
    /// <inheritdoc />
    public partial class addid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserStats_UserStatsId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserStatsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserStatsId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserStats",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserStats_ApplicationUserId",
                table: "UserStats",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserStats_AspNetUsers_ApplicationUserId",
                table: "UserStats",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserStats_AspNetUsers_ApplicationUserId",
                table: "UserStats");

            migrationBuilder.DropIndex(
                name: "IX_UserStats_ApplicationUserId",
                table: "UserStats");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserStats");

            migrationBuilder.AddColumn<int>(
                name: "UserStatsId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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
    }
}
