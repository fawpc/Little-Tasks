using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleTasksWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddResponsableDependentsOnDbset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_ResponsableDependent_ResponsableDependentId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponsableDependent",
                table: "ResponsableDependent");

            migrationBuilder.RenameTable(
                name: "ResponsableDependent",
                newName: "ResponsableDependents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponsableDependents",
                table: "ResponsableDependents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_ResponsableDependents_ResponsableDependentId",
                table: "Tasks",
                column: "ResponsableDependentId",
                principalTable: "ResponsableDependents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_ResponsableDependents_ResponsableDependentId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponsableDependents",
                table: "ResponsableDependents");

            migrationBuilder.RenameTable(
                name: "ResponsableDependents",
                newName: "ResponsableDependent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponsableDependent",
                table: "ResponsableDependent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_ResponsableDependent_ResponsableDependentId",
                table: "Tasks",
                column: "ResponsableDependentId",
                principalTable: "ResponsableDependent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
