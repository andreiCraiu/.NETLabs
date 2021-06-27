using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab_2.Data.Migrations
{
    public partial class UserTaskAssigned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTaskAssigned",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskAssigned", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserTaskAssigned_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskUserTaskAssigned",
                columns: table => new
                {
                    TasksID = table.Column<int>(type: "int", nullable: false),
                    UserTasksID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUserTaskAssigned", x => new { x.TasksID, x.UserTasksID });
                    table.ForeignKey(
                        name: "FK_TaskUserTaskAssigned_Tasks_TasksID",
                        column: x => x.TasksID,
                        principalTable: "Tasks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskUserTaskAssigned_UserTaskAssigned_UserTasksID",
                        column: x => x.UserTasksID,
                        principalTable: "UserTaskAssigned",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskUserTaskAssigned_UserTasksID",
                table: "TaskUserTaskAssigned",
                column: "UserTasksID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskAssigned_ApplicationUserId",
                table: "UserTaskAssigned",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskUserTaskAssigned");

            migrationBuilder.DropTable(
                name: "UserTaskAssigned");
        }
    }
}
