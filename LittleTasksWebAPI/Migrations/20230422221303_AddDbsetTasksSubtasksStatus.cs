using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleTasksWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDbsetTasksSubtasksStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResponsableDependent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ResponsableId = table.Column<Guid>(type: "uuid", nullable: false),
                    DependentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsableDependent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Points = table.Column<double>(type: "double precision", nullable: false),
                    StatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResponsableDependentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_ResponsableDependent_ResponsableDependentId",
                        column: x => x.ResponsableDependentId,
                        principalTable: "ResponsableDependent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Points = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubTasks_TaskId",
                table: "SubTasks",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ResponsableDependentId",
                table: "Tasks",
                column: "ResponsableDependentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubTasks");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "ResponsableDependent");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
