using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleTasksWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddExpirationDateOnTasksAndSubtasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "ExpirationDate",
                table: "Tasks",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "ExpirationDate",
                table: "SubTasks",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "SubTasks");
        }
    }
}
