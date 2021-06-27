using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab_2.Data.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTaskAssigneds_AspNetUsers_ApplicationUserId",
                table: "UserTaskAssigneds");

            migrationBuilder.DropIndex(
                name: "IX_UserTaskAssigneds_ApplicationUserId",
                table: "UserTaskAssigneds");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "UserTaskAssigneds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserTaskAssigneds",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
