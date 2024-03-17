using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trachtenberg_System.Data.UserData
{
    /// <inheritdoc />
    public partial class changetofloat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "AverageAccuracy",
                table: "UserStats",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "AverageAccuracy",
                table: "UserStats",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
