using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab_2.Data.Migrations
{
    public partial class UpdateDbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserTaskAssignedID",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserTaskAssigneds",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateAssigned = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskAssigneds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserTaskAssigneds_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserTaskAssignedID",
                table: "Tasks",
                column: "UserTaskAssignedID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskAssigneds_ApplicationUserId",
                table: "UserTaskAssigneds",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_UserTaskAssigneds_UserTaskAssignedID",
                table: "Tasks",
                column: "UserTaskAssignedID",
                principalTable: "UserTaskAssigneds",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_UserTaskAssigneds_UserTaskAssignedID",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "UserTaskAssigneds");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserTaskAssignedID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserTaskAssignedID",
                table: "Tasks");
        }
    }
}
