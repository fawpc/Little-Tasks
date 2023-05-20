using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleTasksWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusOnSubtask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "SubTasks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SubTasks_StatusId",
                table: "SubTasks",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTasks_Status_StatusId",
                table: "SubTasks",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubTasks_Status_StatusId",
                table: "SubTasks");

            migrationBuilder.DropIndex(
                name: "IX_SubTasks_StatusId",
                table: "SubTasks");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "SubTasks");
        }
    }
}
