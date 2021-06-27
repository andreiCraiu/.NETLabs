using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab_2.Data.Migrations
{
    public partial class UpdateFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_UserTaskAssigneds_UserTaskAssignedID",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserTaskAssignedID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserTaskAssignedID",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "UserTaskAssigneds",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaskUserTaskAssigned",
                columns: table => new
                {
                    TasksID = table.Column<int>(type: "int", nullable: false),
                    UserTaskAssignedsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUserTaskAssigned", x => new { x.TasksID, x.UserTaskAssignedsID });
                    table.ForeignKey(
                        name: "FK_TaskUserTaskAssigned_Tasks_TasksID",
                        column: x => x.TasksID,
                        principalTable: "Tasks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskUserTaskAssigned_UserTaskAssigneds_UserTaskAssignedsID",
                        column: x => x.UserTaskAssignedsID,
                        principalTable: "UserTaskAssigneds",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskAssigneds_ApplicationUserId1",
                table: "UserTaskAssigneds",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_TaskUserTaskAssigned_UserTaskAssignedsID",
                table: "TaskUserTaskAssigned",
                column: "UserTaskAssignedsID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTaskAssigneds_AspNetUsers_ApplicationUserId1",
                table: "UserTaskAssigneds",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTaskAssigneds_AspNetUsers_ApplicationUserId1",
                table: "UserTaskAssigneds");

            migrationBuilder.DropTable(
                name: "TaskUserTaskAssigned");

            migrationBuilder.DropIndex(
                name: "IX_UserTaskAssigneds_ApplicationUserId1",
                table: "UserTaskAssigneds");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "UserTaskAssigneds");

            migrationBuilder.AddColumn<int>(
                name: "UserTaskAssignedID",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserTaskAssignedID",
                table: "Tasks",
                column: "UserTaskAssignedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_UserTaskAssigneds_UserTaskAssignedID",
                table: "Tasks",
                column: "UserTaskAssignedID",
                principalTable: "UserTaskAssigneds",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
