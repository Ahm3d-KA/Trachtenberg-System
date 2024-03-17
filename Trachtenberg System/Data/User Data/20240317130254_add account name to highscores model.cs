﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trachtenberg_System.Data.UserData
{
    /// <inheritdoc />
    public partial class addaccountnametohighscoresmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "HighScores",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "HighScores");
        }
    }
}
