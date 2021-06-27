using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab_2.Data.Migrations
{
    public partial class ModifyTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "UserTaskAssigneds",
                newName: "ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserTaskAssigneds",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskAssigneds_ApplicationUserId",
                table: "UserTaskAssigneds",
                column: "ApplicationUserId");

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
                name: "FK_UserTaskAssigneds_AspNetUsers_ApplicationUserId",
                table: "UserTaskAssigneds");

            migrationBuilder.DropIndex(
                name: "IX_UserTaskAssigneds_ApplicationUserId",
                table: "UserTaskAssigneds");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "UserTaskAssigneds",
                newName: "ApplicationUserID");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "UserTaskAssigneds",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
