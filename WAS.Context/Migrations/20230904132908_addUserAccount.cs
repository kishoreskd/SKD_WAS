using Microsoft.EntityFrameworkCore.Migrations;

namespace WAS.Context.Migrations
{
    public partial class addUserAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserAccountId",
                table: "UserTasks",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserAccountId",
                table: "Project",
                type: "int",
                nullable: true,
                defaultValue: 0);


            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_UserAccountId",
                table: "UserTasks",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_UserAccountId",
                table: "Project",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Employee_UserAccountId",
                table: "Project",
                column: "UserAccountId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Employee_UserAccountId",
                table: "UserTasks",
                column: "UserAccountId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Employee_UserAccountId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Employee_UserAccountId",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_UserTasks_UserAccountId",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_Project_UserAccountId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Project");
        }
    }
}
