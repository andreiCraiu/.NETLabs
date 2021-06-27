using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab_2.Data.Migrations
{
    public partial class updateToBeString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskUserTaskAssigned_UserTaskAssigneds_UserTaskAssignedsID",
                table: "TaskUserTaskAssigned");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTaskAssigneds_AspNetUsers_ApplicationUserId1",
                table: "UserTaskAssigneds");

            migrationBuilder.DropIndex(
                name: "IX_UserTaskAssigneds_ApplicationUserId1",
                table: "UserTaskAssigneds");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "UserTaskAssigneds");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "UserTaskAssigneds",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserTaskAssignedsID",
                table: "TaskUserTaskAssigned",
                newName: "UserTaskAssignedsId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskUserTaskAssigned_UserTaskAssignedsID",
                table: "TaskUserTaskAssigned",
                newName: "IX_TaskUserTaskAssigned_UserTaskAssignedsId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserTaskAssigneds",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskAssigneds_ApplicationUserId",
                table: "UserTaskAssigneds",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskUserTaskAssigned_UserTaskAssigneds_UserTaskAssignedsId",
                table: "TaskUserTaskAssigned",
                column: "UserTaskAssignedsId",
                principalTable: "UserTaskAssigneds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTaskAssigneds_AspNetUsers_ApplicationUserId",
                table: "UserTaskAssigneds",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskUserTaskAssigned_UserTaskAssigneds_UserTaskAssignedsId",
                table: "TaskUserTaskAssigned");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTaskAssigneds_AspNetUsers_ApplicationUserId",
                table: "UserTaskAssigneds");

            migrationBuilder.DropIndex(
                name: "IX_UserTaskAssigneds_ApplicationUserId",
                table: "UserTaskAssigneds");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserTaskAssigneds",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserTaskAssignedsId",
                table: "TaskUserTaskAssigned",
                newName: "UserTaskAssignedsID");

            migrationBuilder.RenameIndex(
                name: "IX_TaskUserTaskAssigned_UserTaskAssignedsId",
                table: "TaskUserTaskAssigned",
                newName: "IX_TaskUserTaskAssigned_UserTaskAssignedsID");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "UserTaskAssigneds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "UserTaskAssigneds",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskAssigneds_ApplicationUserId1",
                table: "UserTaskAssigneds",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskUserTaskAssigned_UserTaskAssigneds_UserTaskAssignedsID",
                table: "TaskUserTaskAssigned",
                column: "UserTaskAssignedsID",
                principalTable: "UserTaskAssigneds",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTaskAssigneds_AspNetUsers_ApplicationUserId1",
                table: "UserTaskAssigneds",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
